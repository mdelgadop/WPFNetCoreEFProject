using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Patterns
{
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
