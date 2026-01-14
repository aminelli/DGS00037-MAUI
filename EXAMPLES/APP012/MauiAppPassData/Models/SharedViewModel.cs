using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPassData.Models
{
    public class SharedViewModel : INotifyPropertyChanged
    {

        private string _sharedData;
        private int _counter;
        
        public string SharedData
        {
            get => _sharedData;
            set
            {
                if (_sharedData != value)
                {
                    _sharedData = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Counter
        {
            get => _counter;
            set
            {
                if (_counter != value)
                {
                    _counter = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




    }

}
