using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
public partial class OrganismeView : BasePage
{
    private OrganismeVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }
    public OrganismeView()
    {
        InitializeComponent();
        BindingContext = vm = new OrganismeVM();
        vm.assignDades(Organisme);
    }

    private void ModificarPerfil(object sender, EventArgs e)
    {
        string nom = txtNomPerfil.Text;
        string email = txtEmailPerfil.Text;
        string contraseña = txtPasswordPerfil.Text;
        Organisme.nom = nom;
        Organisme.email = email;
        Organisme.password = contraseña;
        vm.modificarOrganisme();
    }

    private void EliminarPerfil(object sender, EventArgs e)
    {
        vm.eliminarOrganisme();
    }

    private void CancelarCambios(object sender, EventArgs e)
    {
        this.Navigation.PopModalAsync();
    }
}