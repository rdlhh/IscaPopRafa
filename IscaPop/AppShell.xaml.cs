namespace IscaPop
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(View.Login), typeof(View.Login));
            Routing.RegisterRoute(nameof(View.BotonsView), typeof(View.BotonsView));
            Routing.RegisterRoute(nameof(View.OrganismeView), typeof(View.OrganismeView));
        }
    }
}
