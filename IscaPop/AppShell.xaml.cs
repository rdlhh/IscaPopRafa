namespace IscaPop
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(View.Opciones), typeof(View.Opciones));
            Routing.RegisterRoute(nameof(View.IniciarSesionView), typeof(View.IniciarSesionView));
            Routing.RegisterRoute(nameof(View.Login), typeof(View.Login));
            Routing.RegisterRoute(nameof(View.ContrasenyaView), typeof(View.ContrasenyaView));
            Routing.RegisterRoute(nameof(View.BotonsView), typeof(View.BotonsView));
            Routing.RegisterRoute(nameof(View.OrganismeView), typeof(View.OrganismeView));
            Routing.RegisterRoute(nameof(View.MaterialView), typeof(View.MaterialView));
            Routing.RegisterRoute(nameof(View.HacerFotoView), typeof(View.HacerFotoView));
        }
    }
}
