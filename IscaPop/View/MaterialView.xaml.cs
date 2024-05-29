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
        try
        {
            vm.insertMaterial(Material);
            Organisme.materialsCollection.Add(mat);
            vm.assignDadesOrganisme(Organisme);
            DisplayAlert("Material", "El material ha sigut a afegit correctament", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", "Ha ocorregut un error al crear el material", "OK");
        }

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
        try
        {
            vm.modMaterial();
            DisplayAlert("Material", "El material ha sigut modificat correctament", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", "Ha ocorregut un error al modificar el material", "OK");
        }


    }

    private void BorrarClick(object sender, EventArgs e)
    {
        try
        {
            vm.borrarMaterial();
            DisplayAlert("Material", "El material ha sigut eliminat correctament", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", "Ha ocorregut un error al eliminar el material", "OK");
        }

    }
}