namespace MauiAppPassData;

public class DataUpdatedEventArgs: EventArgs
{
    public string Data { get; set; }

    public DataUpdatedEventArgs()
    {
        Data = "data";
    }

    public DataUpdatedEventArgs(string data)
    {
        Data = data;
    }
}


public partial class EventHandlerPage : ContentPage
{
	

	public EventHandlerPage()
	{
		InitializeComponent();
	}

    private async void OnNavigateWithCallback(object sender, EventArgs e)
    {
        var page = new EventHandlerNextPage();
        page.DataUpdated += OnDataUpdated;
        await Navigation.PushAsync(page);
    }


    private void OnDataUpdated(object sender, DataUpdatedEventArgs e)
    {
        ReceivedData.Text = $"Received data: {e.Data}";
    }


}