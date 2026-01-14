using MauiAppPassData.Services;
using System.Data;

namespace MauiAppPassData;

public partial class ServicePage : ContentPage
{

	private readonly IDataService _dataService;


    public ServicePage(IDataService dataService)
	{
		InitializeComponent();
		_dataService = dataService;

		_dataService.DataChanged += OnDataChanged;
        DataEntry.Text = _dataService.Data ?? "Nessun dato";
    }

	private void OnDataChanged(object sender, String data)
    {
        DataEntry.Text = data;
        //ReceivedData.Text = $"Received data: {_dataService.Data}";
    }

    private void OnUpdateData(object sender, EventArgs e)
    {
        _dataService.Data = DataEntry.Text;
    }

    private async void OnNavigateToDetail(Object sender, EventArgs e) { 
        await Navigation.PushAsync(new ServiceDetailPage(_dataService));
    }



}