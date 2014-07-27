using ServiceReminder.Models;
using ServiceReminder.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ServiceReminder
{
	public class App
	{
		public static Page GetMainPage()
		{
            return new EditReminderPage();
		}

        public static ReminderItem SelectedModel { get; set; }
	}
}
