namespace MauiAppPassData
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("querydetail", typeof(QueryDetailPage));

        }
    }
}
