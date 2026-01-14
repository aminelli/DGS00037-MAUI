using CommunityToolkit.Mvvm.Messaging;
using MauiAppPassData.Business;

namespace MauiAppPassData;

public partial class MessagingSecondPage : ContentPage
{
	public MessagingSecondPage()
	{
		InitializeComponent();

		WeakReferenceMessenger.Default.Register<DataToMessage>(this, (r, m) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ReceivedLabel.Text = $"Ricevuto messaggio: {m.Value.Message} alle {m.Value.Timestamp:HH:mm:ss}";
                //ResponseLabel.Text = $"Ricevuto messaggio: {m.Value.Message} alle {m.Value.Timestamp}";
            });
        });
    }
    private async void OnSendBack(object sender, EventArgs e)
    {
        var message = new DataMessage
        {
            Message = ResponseEntry.Text,
            Timestamp = DateTime.Now
        };
        WeakReferenceMessenger.Default.Send(new DataFromMessage(message));
        
        await Navigation.PopAsync();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // pulizia per evitare memory leaks
        // non obbligatorio ma best practices
        WeakReferenceMessenger.Default.Unregister<DataToMessage>(this);

    }


}