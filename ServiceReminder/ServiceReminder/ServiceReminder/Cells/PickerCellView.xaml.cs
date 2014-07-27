using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServiceReminder.Cells
{
	public partial class PickerCellView
	{
		public PickerCellView ()
		{
			InitializeComponent ();

            picker.SelectedIndexChanged += picker_SelectedIndexChanged;
           
		}

        public void PopulatePicker()
        {
            var pickerViewModel = (IPickerCellViewModel)BindingContext;
            foreach (var item in pickerViewModel.Items)
            {
                picker.Items.Add(item);
            }
            picker.SelectedIndex = 0;
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pickerViewModel = (IPickerCellViewModel)BindingContext;
            if (pickerViewModel!=null && pickerViewModel.SelectionChangedCommand != null)
            pickerViewModel.SelectionChangedCommand.Execute(picker.SelectedIndex);
        }
	}

    public class PickerCell<T> : ViewCell
    {
        public static readonly BindableProperty PickerCellViewModelProperty =
                BindableProperty.Create<PickerCell<T>, T>(p => p.PickerCellViewModel, Activator.CreateInstance<T>());
  
        public T PickerCellViewModel
        {
            get { return (T)GetValue(PickerCellViewModelProperty); }
            set { SetValue(PickerCellViewModelProperty, value); }
        }

        public PickerCell()
        {
            var vw = new PickerCellView();
            vw.BindingContext = PickerCellViewModel;
            vw.PopulatePicker();
            View = vw;
            
        }



    }
}
