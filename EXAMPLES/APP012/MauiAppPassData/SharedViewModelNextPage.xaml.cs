using MauiAppPassData.Models;

namespace MauiAppPassData;

public partial class SharedViewModelNextPage : ContentPage
{
	public SharedViewModelNextPage(SharedViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

	}

	private void OnIncrement(object sender, EventArgs e)
    {
        if (BindingContext is SharedViewModel viewModel)
        {
            viewModel.Counter++;
        }
    }


}