using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
[QueryProperty(nameof(Material), "MaterialSelected")]
public partial class MaterialView : BasePage
{
    private MaterialVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDadesOrganisme(Organisme); }
    }

    private Material material;
    public Material Material
    {
        get { return material; }
        set { SetProperty(ref material, value); vm.assignDades(material); }
    }



    public MaterialView()
    {
        InitializeComponent();
        BindingContext = vm = new MaterialVM();
        vm.assignDadesOrganisme(Organisme);
        Material = vm.Material;
    }

    private async void HacerFotoClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(HacerFotoView)}",
             new Dictionary<string, object>
             {
                 { "Material", Material }
             }
            );
    }

    private void AñadirClick(object sender, EventArgs e)
    {
        string nom = txtNom.Text;
        string uso = txtUso.Text;
        string descripcio = txtDescripcio.Text;
        EnumEstadoMaterial estat = (EnumEstadoMaterial)Enum.Parse(typeof(EnumEstadoMaterial), (string)pickerEstat.SelectedItem);
        Material mat = new Material();
        mat.nom = nom;
        mat.uso = uso;
        mat.descripcio = descripcio;
        mat.estat = estat;
        mat.organisme = Organisme;
        Material = mat;
        vm.insertMaterial(Material);
        Organisme.materialsCollection.Add(mat);
        vm.assignDadesOrganisme(Organisme);
    }

    private void ModClick(object sender, EventArgs e)
    {
        string nom = txtNom.Text;
        string uso = txtUso.Text;
        string descripcio = txtDescripcio.Text;
        int stock = Convert.ToInt32(txtStock.Text);
        EnumEstadoMaterial estat = (EnumEstadoMaterial)Enum.Parse(typeof(EnumEstadoMaterial), (string)pickerEstat.SelectedItem);
        Material.nom = nom;
        Material.uso = uso;
        Material.descripcio = descripcio;
        Material.stock = stock;
        Material.estat = estat;
        vm.modMaterial();

    }

    private void BorrarClick(object sender, EventArgs e)
    {
        vm.borrarMaterial();
    }
}