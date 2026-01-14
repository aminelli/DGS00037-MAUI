namespace MauiAppPassData;

public partial class EventHandlerNextPage : ContentPage
{

	public event EventHandler<DataUpdatedEventArgs> DataUpdated;

    public EventHandlerNextPage()
	{
		InitializeComponent();
	}

	private async void OnSendDataBack(object sender, EventArgs e)
    {
        var data = DataEntry.Text ?? "No Data";
        DataUpdated?.Invoke(this, new DataUpdatedEventArgs {
            Data = data
        });
        await Navigation.PopAsync();
    }


}