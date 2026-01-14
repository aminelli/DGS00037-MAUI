namespace MauiAppPassData;

public partial class QueryParamsPage : ContentPage
{
	public QueryParamsPage()
	{
		InitializeComponent();
	}


	private async void OnNavigateWithParams(object sender, EventArgs e)
	{
		var name = NameEntry.Text;
		var age = AgeEntry.Text;

		await Shell.Current.GoToAsync($"querydetail?name={name}&age={age}");
	}

}