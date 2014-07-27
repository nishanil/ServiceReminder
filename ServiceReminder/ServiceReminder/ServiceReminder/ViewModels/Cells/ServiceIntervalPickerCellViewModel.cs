using ServiceReminder.Cells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ServiceReminder.ViewModels
{
    public class ServiceIntervalPickerCellViewModel : ObservableObject, IPickerCellViewModel
    {
        private const string Monthly = "Monthly";
        private const string Quarterly = "Quarterly";
        private const string HalfYearly = "Half Yearly";

        private const string Yearly = "Yearly";


        public ServiceIntervalPickerCellViewModel()
        {
            Items = new ObservableCollection<string>();
            Items.Add(Monthly);
            Items.Add(Quarterly);
            Items.Add(HalfYearly);

            Items.Add(Yearly);

            SelectionChangedCommand = new Command((index) =>
            {
                App.SelectedModel.NextServiceDate = App.SelectedModel.LastServiceDate;
                var selectedIndex = Convert.ToInt32(index);
                var selectedItem = Items[selectedIndex];
                if (selectedItem == Monthly)
                    App.SelectedModel.NextServiceDate.AddMonths(1);
                if (selectedItem == Quarterly)
                    App.SelectedModel.NextServiceDate.AddMonths(3);
                if (selectedItem == HalfYearly)
                    App.SelectedModel.NextServiceDate.AddMonths(6);
                if (selectedItem == Yearly)
                   App.SelectedModel.NextServiceDate.AddMonths(12);

            });

        }
        private string pickerText = "Service Interval:";

        public string PickerText
        {
            get { return pickerText; }
            set { pickerText = value; OnPropertyChanged(); }
        }

        private string pickerTitle = "Select Interval";

        public string PickerTitle
        {
            get { return pickerTitle; }
            set { pickerTitle = value; OnPropertyChanged(); }
        }

        private Command selectionChangedCommand;

        public Command SelectionChangedCommand
        {
            get { return selectionChangedCommand; }
            set { selectionChangedCommand = value; OnPropertyChanged(); }
        }

        private IList<string> items;

        public IList<string> Items
        {
            get { return items; }
            set { items = value; OnPropertyChanged(); }
        }
    }
}
