using MauiAppPassData.Models;

namespace MauiAppPassData;

public partial class SharedViewModelPage : ContentPage
{

	private SharedViewModel _viewModel;


	public SharedViewModelPage(SharedViewModel viewModel = null)
	{
		InitializeComponent();
		_viewModel = viewModel ?? new SharedViewModel();
        BindingContext = _viewModel;
    }

	private async void OnNavigateNextPage(object sender, EventArgs e)
    {
		_viewModel.SharedData = DataEntry.Text;
        await Navigation.PushAsync(new SharedViewModelNextPage(_viewModel));
    }	


}