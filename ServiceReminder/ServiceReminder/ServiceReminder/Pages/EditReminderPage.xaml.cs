using ServiceReminder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServiceReminder.Pages
{
	public partial class EditReminderPage
	{

        EditReminderPageViewModel vm;
		public EditReminderPage ()
		{
			InitializeComponent ();

             vm = new EditReminderPageViewModel();
            vm.Navigation = Navigation;
            this.BindingContext = vm;
            SetBinding(Page.TitleProperty, new Binding(EditReminderPageViewModel.TitlePropertyName));
            SetBinding(Page.IconProperty, new Binding(EditReminderPageViewModel.IconPropertyName));

            //ToolbarItems.Clear();
            //ToolbarItems.Add(new ToolbarItem("Save", null, async ()=> {
                
            //}));
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }


	}
}
