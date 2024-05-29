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
        try
        {
            vm.modificarOrganisme();
            DisplayAlert("Detall Organisme", "L'organisme ha sigut modificat correctament", "OK");

        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", "Ha ocurregut un error al modificar l'organisme", "OK");
        }


    }

    private void EliminarPerfil(object sender, EventArgs e)
    {
        try
        {
            vm.eliminarOrganisme();
            DisplayAlert("Organisme eliminat", "L'organisme ha sigut eliminat correctament", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", "Ha ocurregut un error al eliminar l'organisme", "OK");
        }
    }

    private void CancelarCambios(object sender, EventArgs e)
    {
        this.Navigation.PopModalAsync();
    }
}