using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hsh.Mvvm.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T item, T value, string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(item, value))
            {
                return false;
            }

            item = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
