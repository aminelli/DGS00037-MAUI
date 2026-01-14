
namespace MauiAppPassData.Services
{

    public interface IDataService
    {
        string Data { get; set; }
        event EventHandler<String> DataChanged;
    }

    public class DataService : IDataService
    {
        private string _data = string.Empty;

        public string Data
        {
            get => _data;
            set
            {
                if (_data != value)
                {
                    _data = value;
                    DataChanged?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<String> DataChanged;
    }
}
