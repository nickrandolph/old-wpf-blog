using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataBoundDialogBox
{
    public class DataSource : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private string comment;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Comment)));
            }
        }
    }
}
