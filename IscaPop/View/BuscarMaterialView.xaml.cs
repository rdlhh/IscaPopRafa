using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
public partial class BuscarMaterialView : BasePage
{
	private BuscarMaterialVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDadesOrganisme(Organisme); }
    }
    public BuscarMaterialView()
	{
		InitializeComponent();
        BindingContext = vm = new BuscarMaterialVM();
        vm.assignDadesOrganisme(Organisme);
	}

    private async void BuscarClick(object sender, EventArgs e)
    {
        String nom = txtNom.Text;
        String uso = txtUso.Text;
        String descripcio = txtDescripcio.Text;
        EnumEstadoMaterial estat = (EnumEstadoMaterial)Enum.Parse(typeof(EnumEstadoMaterial), (string)pickerEstat.SelectedItem);
        await Shell.Current.GoToAsync($"{nameof(MaterialBuscat)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme },
                 { "Nom", nom },
                 { "Uso", uso },
                 { "Descripcio", descripcio },
                 { "Estat", estat }
             }
            );
    }
}