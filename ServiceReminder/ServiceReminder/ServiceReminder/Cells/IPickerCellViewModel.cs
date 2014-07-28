using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ServiceReminder.Cells
{
    public interface IPickerCellViewModel : INotifyPropertyChanged
    {
        string PickerText { get; set; }

        string PickerTitle { get; set; }

        Command SelectionChangedCommand { get; set; }

        IList<string> Items { get; set; }

        object SelectedItem { get; set; }
    }

    //public class PickerCellViewModel : ObservableObject, IPickerCellViewModel
    //{
    //    private string pickerText;

    //    public string PickerText
    //    {
    //        get { return pickerText; }
    //        set { pickerText = value; OnPropertyChanged(); }
    //    }

    //    private string pickerTitle;

    //    public string PickerTitle
    //    {
    //        get { return pickerTitle; }
    //        set { pickerTitle = value; OnPropertyChanged(); }
    //    }

    //    private Command selectionChangedCommand;

    //    public Command SelectionChangedCommand
    //    {
    //        get { return selectionChangedCommand; }
    //        set { selectionChangedCommand = value; OnPropertyChanged(); }
    //    }

    //    private IList<string> items;

    //    public IList<string> Items
    //    {
    //        get { return items; }
    //    }

    //}
}
