using CommunityToolkit.Mvvm.Messaging;

namespace DecoupleViewAndViewModel {
    public partial class MainPage : ContentPage {
        //public MainPage(MyViewModel viewModel)
        public MainPage()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<Customer>(
                this, 
                (r, customer) =>
                {
                    customersCollectionView.ScrollTo(customer);
                    //BindingContext = viewModel;
               
                }
             );
           
           
        }

        /*
        protected override void OnDisappearing() {
            base.OnDisappearing();

            if (BindingContext is IRecipient<Customer> recipient) {
                WeakReferenceMessenger.Default.Unregister<Customer>(recipient);
            }

        }
        */


    }

}
