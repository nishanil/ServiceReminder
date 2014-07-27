using ServiceReminder.Cells;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ServiceReminder.ViewModels
{
    public class EditReminderPageViewModel : ObservableObject
    {

        public EditReminderPageViewModel ()
	    {
            lastServiceDate = DateTime.Now;
	    }
        private string name;

	    public string Name
	    {
		    get { return name;}
		    set { name = value;
                 App.SelectedModel.Name = value;
                OnPropertyChanged();}
	    }

        private string registrationNo;

	    public string RegistrationNumber
	    {
		    get { return registrationNo;}
		    set { registrationNo = value; App.SelectedModel.RegistrationNumber = value; OnPropertyChanged();}
	    }

        private DateTime lastServiceDate;

	    public DateTime LastServiceDate
	    {
		    get { return lastServiceDate;}
		    set { lastServiceDate = value; App.SelectedModel.LastServiceDate = value; OnPropertyChanged();}
	    }
	
    }

    

}
