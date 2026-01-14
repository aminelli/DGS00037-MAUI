using MauiAppPassData.Services;
using System.Data;

namespace MauiAppPassData;

public partial class ServiceDetailPage : ContentPage
{
    private readonly IDataService _dataService;


    public ServiceDetailPage(IDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;

        DataEntry.Text = _dataService.Data ?? "Nessun dato";
    }

    private void OnUpdateData(object sender, EventArgs e)
    {
        _dataService.Data = DataEntry.Text;
    }

    private async void OnGoBack(Object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }


}