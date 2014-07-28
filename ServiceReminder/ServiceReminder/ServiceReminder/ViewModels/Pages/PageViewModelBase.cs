using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceReminder.ViewModels
{
    public class PageViewModelBase : ObservableObject
    {
        public const string TitlePropertyName = "Title";

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }


        private string icon = null;

        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return icon; }
            set { icon = value; OnPropertyChanged(); }
        }
    }
}
