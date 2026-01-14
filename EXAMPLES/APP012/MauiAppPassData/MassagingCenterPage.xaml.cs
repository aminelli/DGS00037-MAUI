using CommunityToolkit.Mvvm.Messaging;
using MauiAppPassData.Business;

namespace MauiAppPassData;

public partial class MassagingCenterPage : ContentPage
{

	public MassagingCenterPage()
	{
		InitializeComponent();

		WeakReferenceMessenger.Default.Register<DataFromMessage>(this, (r, m) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ResponseLabel.Text = $"Ricevuto messaggio: {m.Value.Message} alle {m.Value.Timestamp}";
            });
        });

    }

    private async void OnSendMessage(object sender, EventArgs e)
    {
        var message = new DataMessage
        {
            Message = MessageEntry.Text,
            Timestamp = DateTime.Now
        };

        var page = new MessagingSecondPage();

        WeakReferenceMessenger.Default.Send(new DataToMessage(message));

        await Navigation.PushAsync(page);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // pulizia per evitare memory leaks
        // non obbligatorio ma best practices

        // WeakReferenceMessenger.Default.Unregister<DataFromMessage>(this);
    }


}