using ServiceReminder.Data;
using ServiceReminder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceReminder.Pages
{
	public partial class HomePage
	{
        HomePageViewModel vm;
		public HomePage ()
		{
			InitializeComponent ();

            this.BindingContext = vm = new HomePageViewModel();

            listView.ItemSelected += listView_ItemSelected;

            ToolbarItems.Add(new Xamarin.Forms.ToolbarItem("Add", null, async () =>
            {
                App.SelectedModel = null;
                await Navigation.PushAsync(new EditReminderPage());
            }, 0, 0));
 
		}

        async void listView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            App.SelectedModel = new ReminderItemDatabase().GetItem((e.SelectedItem as ReminderListItem).Id);
            await Navigation.PushAsync(new EditReminderPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.PopulateReminderList();
            listView.ItemsSource = vm.ReminderList;

        }



	}
}
