using DecoupleViewAndViewModel.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DecoupleViewAndViewModel.ViewModels
{
    public class MainViewModel2 : INotifyPropertyChanged
    {
        private string _message = "Pronto per iniziare";
        private bool _isDataValid = true;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel2()
        {
            // Command senza parametro
            LoadDataCommand = new AsyncCommand(
                execute: LoadDataAsync,
                canExecute: () => IsDataValid
            );

            // Command con parametro
            SaveItemCommand = new AsyncCommand<string>(
                execute: SaveItemAsync,
                canExecute: (item) => !string.IsNullOrEmpty(item)
            );

            // Command semplice senza CanExecute
            RefreshCommand = new AsyncCommand(RefreshAsync);
        }

        public AsyncCommand LoadDataCommand { get; }
        public AsyncCommand<string> SaveItemCommand { get; }
        public AsyncCommand RefreshCommand { get; }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public bool IsDataValid
        {
            get => _isDataValid;
            set
            {
                _isDataValid = value;
                OnPropertyChanged();
                LoadDataCommand.RaiseCanExecuteChanged();
            }
        }

        private async Task LoadDataAsync()
        {
            Message = "Caricamento in corso...";

            // Simula operazione asincrona
            await Task.Delay(2000);

            Message = "Dati caricati con successo!";
        }

        private async Task SaveItemAsync(string? item)
        {
            if (string.IsNullOrEmpty(item))
                return;

            Message = $"Salvataggio di '{item}'...";

            await Task.Delay(1000);

            Message = $"'{item}' salvato con successo!";
        }

        private async Task RefreshAsync()
        {
            Message = "Aggiornamento in corso...";
            await Task.Delay(1500);
            Message = "Aggiornato alle " + DateTime.Now.ToString("HH:mm:ss");
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}