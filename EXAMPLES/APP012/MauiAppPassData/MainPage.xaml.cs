using System.Collections.ObjectModel;

namespace MauiAppPassData
{
    public partial class MainPage : ContentPage
    {
        
        public ObservableCollection<string> Techniques { get; set; }



        public MainPage()
        {
            InitializeComponent();

            Techniques = new ObservableCollection<string>
            {
                "1. Query Parameters (Semplice, ed è unidirezionale)",
                "2. Weak Ref Messenger (Communit Toolit)",
                "3. Shared View Model (Best Practices)",
                "4. Event Handler (Controllo Diretto)"
            };

            BindingContext = this;

        }

        private async void OnTechniqueSelected(Object sender, SelectedItemChangedEventArgs e) {

            if (e.SelectedItem == null) return;

            var selected = e.SelectedItem.ToString();

            if (selected.Contains("1.")) {
                await Navigation.PushAsync(new QueryParamsPage());
            } else if (selected.Contains("2."))
            {
                await Navigation.PushAsync(new MassagingCenterPage());
            }
            else if (selected.Contains("3."))
            {
                await Navigation.PushAsync(new SharedViewModelPage());
            }
            else if (selected.Contains("4."))
            {
                await Navigation.PushAsync(new EventHandlerPage());
            }

            ((ListView)sender).SelectedItem = null;

        }



    }

}
