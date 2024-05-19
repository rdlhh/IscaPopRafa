using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
public partial class LlistaMaterialView : BasePage
{
	private Organisme organisme;
	public Organisme Organisme
	{
		get { return organisme; }
		set { SetProperty(ref organisme, value); }
	}
    private Material material;
    public Material Material
    {
        get { return material; }
        set { SetProperty(ref material, value); }
    }

    private LlistaMaterialVM vm;
	public LlistaMaterialView(Organisme organisme)
	{
		InitializeComponent();
		BindingContext = vm = new LlistaMaterialVM(organisme);
		Loaded += OnLoad;
	}

    private void OnLoad(object? sender, EventArgs e)
    {
		vm.AssignaDadesO(Organisme);
    }

    public async void AssignaDades()
	{
		vm.AssignaDades();
		Material material;
	}

    private async void MaterialTapped(object sender, ItemTappedEventArgs e)
    {
        Material mat = e.Item as Material;

        await Shell.Current.GoToAsync($"{nameof(MaterialView)}",
             new Dictionary<string, object>
             {
                 { "MaterialSelected", mat }
             }
        );
    }

    private async void NouClick(object sender, EventArgs e)
    {
		Material material = new Material();
        await Shell.Current.GoToAsync($"{nameof(MaterialView)}",
             new Dictionary<string, object>
             {
                 { "MaterialSelected", material }
             }
        );
    }
}