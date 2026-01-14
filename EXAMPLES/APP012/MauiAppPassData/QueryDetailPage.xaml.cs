using System.Xml.Linq;

namespace MauiAppPassData;


[QueryProperty(nameof(Name), "name")]
[QueryProperty(nameof(Age), "age")]
public partial class QueryDetailPage : ContentPage
{
	private string _name;
	private string _age;

	public String Name {
		get => _name;
		set {
			_name = value;
			OnPropertyChanged();
		}
	}


    public String Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged();
        }
    }


    public QueryDetailPage()
	{
		InitializeComponent();
		BindingContext = this;
	}
}