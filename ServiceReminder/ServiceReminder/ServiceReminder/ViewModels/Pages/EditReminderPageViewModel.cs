using ServiceReminder.Cells;
using ServiceReminder.Data;
using ServiceReminder.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServiceReminder.ViewModels
{
    public class EditReminderPageViewModel : PageViewModelBase
    {

        public INavigation Navigation { get; set; }

        VehicleListPicker vehicleListPicker;
        public EditReminderPageViewModel()
        {
           
            // If SelectedModel is null then the screen is Add else Edit
            if (App.SelectedModel == null)
            {
                
                this.Title = "Add Service Reminder";
                App.SelectedModel = new Models.ReminderItem();
                App.SelectedModel.LastServiceDate =  DateTime.Now;
                App.SelectedModel.NextServiceDate = DateTime.Now.AddMonths(1);
                App.SelectedModel.IsReminderEnabled = true;
                App.SelectedModel.NextReminder = App.SelectedModel.NextServiceDate.AddDays(-1);
                LastServiceDate = DateTime.Now;
               
                VehicleType = "Car";
            }
            else
            {
                this.Title = "Edit Service Reminder";
                

            }

         
            ChooseVehichleTypeCommand = new Command(async () => {

                vehicleListPicker = new VehicleListPicker();
                if (Navigation != null)
                    await Navigation.PushAsync(vehicleListPicker);
            });

            SaveCommand = new Command(async () =>
            {
                Save();
            });
        }

        public Command SaveCommand { get; set; }

        async public Task<bool> Save()
        {
            if (App.SelectedModel != null && !string.IsNullOrEmpty(App.SelectedModel.Name) && !string.IsNullOrEmpty(App.SelectedModel.RegistrationNumber))
            {
                new ReminderItemDatabase().SaveItem(App.SelectedModel);

                await Navigation.PopAsync();
            }
            else
                return false;

            return true;
        
        }

        public void OnAppearing()
        {
            if (vehicleListPicker != null)
                VehicleType = vehicleListPicker.SelectedVehicle;

            
        }



        public string Name
        {
            get { return App.SelectedModel.Name; }
            set
            {
                App.SelectedModel.Name = value;
                OnPropertyChanged();
            }
        }

        public string RegistrationNo
        {
            get { return App.SelectedModel.RegistrationNumber; }
            set { App.SelectedModel.RegistrationNumber = value; OnPropertyChanged(); }
        }


        public DateTime LastServiceDate
        {
            get { return App.SelectedModel.LastServiceDate; }
            set { App.SelectedModel.LastServiceDate = value; 
                ServiceIntervalPickerCellViewModel.CalculateNextServiceDate(SelectedServiceInterval); 
                OnPropertyChanged("NextServiceDate"); OnPropertyChanged(); }
        }

        private string selectedServiceInterval;

        public string SelectedServiceInterval
        {
            get { return selectedServiceInterval; }
            set { selectedServiceInterval = value; OnPropertyChanged("NextServiceDate"); }
        }
        

        public string NextServiceDate
        {
            get { return App.SelectedModel.NextServiceDate.ToString("d"); }
        }


        public string VehicleType 
        {
            get { return App.SelectedModel.VehicleType; }
            set 
            { 
                App.SelectedModel.VehicleType = value;
                VehiclePhoto = VehicleType + ".png";
                OnPropertyChanged(); 
            }
        }


        public bool IsReminder
        {
            get { return App.SelectedModel.IsReminderEnabled; }
            set { App.SelectedModel.IsReminderEnabled = value; OnPropertyChanged(); }
        }
        

        private string vehiclePhoto;        

        public string VehiclePhoto
        {
            get { return vehiclePhoto; }
            set { vehiclePhoto = value; OnPropertyChanged(); }
        }

        private Command chooseVehichleTypeCommand;

        public Command ChooseVehichleTypeCommand
        {
            get { return chooseVehichleTypeCommand; }
            set { chooseVehichleTypeCommand = value; OnPropertyChanged(); }
        }
        
	
    }

    

}
