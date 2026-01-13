using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DecoupleViewAndViewModel {

    /*
    public class UpdateTextCommand2 : ICommand
    {

        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private bool _isExecuting;

        public UpdateTextCommand2(Func<Tak>) ....

    }
    */

    public class MainViewModel : INotifyPropertyChanged {
        int count = 0;
        string textValue = "Click Me!";
        public string TextValue {
            get {
                return textValue;
            }
            set {
                textValue = value;
                OnPropertyChanged();
            }
        }
        public ICommand UpdateTextCommand {
            get;
            set;
        }

        /*
        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set {
                _isBusy = value;
                OnPropertyChanged();
                UpdateTextCommand2.CanExecuteChanged?.ib
            

            }
        }
       

        public async Task LoadAsync() {
            IsBusy = true;
            try
            {
                await Task.Delay(3000);
            }
            finally {
                IsBusy = false;
            }
        }

         */

        public MainViewModel() {
            UpdateTextCommand = new Command(UpdateText);

            //UpdateTextCommand = new Command(async () => await LoadAsync(),() => !IsBusy);
        }
        public void UpdateText() {
            count++;
            if (count == 1)
                TextValue = $"Clicked {count} time";
            else
                TextValue = $"Clicked {count} times";
        }
        
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }

}
