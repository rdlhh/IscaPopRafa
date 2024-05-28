using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
[QueryProperty(nameof(String), "Nom")]
[QueryProperty(nameof(String), "Uso")]
[QueryProperty(nameof(String), "Descripcio")]
[QueryProperty(nameof(EnumEstadoMaterial), "Estat")]
public partial class MaterialBuscat : BasePage
{
	private MaterialBuscatVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDadesOrganisme(Organisme); }
    }

    private String nom;
    public String Nom
    {
        get { return nom; }
        set { SetProperty(ref nom, value); vm.assignDadesNom(nom); }
    }

    private String uso;
    public String Uso
    {
        get { return uso; }
        set { SetProperty(ref uso, value); vm.assignDadesUso(uso); }
    }

    private String descripcio;
    public String Descripcio
    {
        get { return descripcio; }
        set { SetProperty(ref descripcio, value); vm.assignDadesDescripcio(descripcio); }
    }

    private EnumEstadoMaterial estat;
    public EnumEstadoMaterial Estat
    {
        get { return estat; }
        set { SetProperty(ref estat, value); vm.assignDadesEstat(estat); }
    }
    public MaterialBuscat()
	{
		InitializeComponent();
        BindingContext = vm = new MaterialBuscatVM();
        vm.assignDadesOrganisme(Organisme);
        vm.assignDadesNom(Nom);
        vm.assignDadesUso(Uso);
        vm.assignDadesDescripcio(Descripcio);
        vm.assignDadesEstat(Estat);
        Loaded += OnLoad;
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        vm.getMaterialesNoOrganisme();
    }

    private void MaterialSeleccionado(object sender, ItemTappedEventArgs e)
    {

    }
}