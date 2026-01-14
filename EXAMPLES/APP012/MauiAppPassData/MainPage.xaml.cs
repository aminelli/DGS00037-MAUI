using System.Collections.ObjectModel;

namespace MauiAppPassData
{
    public partial class MainPage : ContentPage
    {
        
        public ObservableCollection<string> Techniques { get; set; }

        private readonly IServiceProvider _serviceProvider;

        public MainPage(IServiceProvider serviceProvider = null)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            Techniques = new ObservableCollection<string>
            {
                "1. Query Parameters (Semplice, ed è unidirezionale)",
                "2. Weak Ref Messenger (Communit Toolit)",
                "3. Shared View Model (Best Practices)",
                "4. Event Handler (Controllo Diretto)",
                "5. DI e IoC (Singleton con stato globale condiviso)"
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
            else if (selected.Contains("5.") && _serviceProvider != null)
            {
                var page = _serviceProvider.GetRequiredService<ServicePage>();
                await Navigation.PushAsync(page);
                //await Navigation.PushAsync(new ServicePage());
            }

            ((ListView)sender).SelectedItem = null;

        }



    }

}
