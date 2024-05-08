using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "Organisme")]
public partial class ContrasenyaView : BasePage
{
    private ContrasenyaVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }
    public ContrasenyaView()
    {
        InitializeComponent();
        BindingContext = vm = new ContrasenyaVM();
        vm.assignDades(Organisme);
    }

    private async void DefinirContraseñaClick(object sender, EventArgs e)
    {
        Organisme.password = txtPassword.Text;
        Organisme.momento = DateTime.Now;
        vm.insertarOrganisme();

        await Shell.Current.GoToAsync($"{nameof(IniciarSesionView)}");
    }
}