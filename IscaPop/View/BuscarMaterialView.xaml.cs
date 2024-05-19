using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;
using ThreadNetwork;

namespace IscaPop.View;

public partial class BuscarMaterialView : BasePage
{
	private BuscarMaterialsVM vm;
	public BuscarMaterialView()
	{
        InitializeComponent();
		BindingContext = vm = new BuscarMaterialsVM();
	}

    private void OrdenarNombre(object sender, EventArgs e)
    {
        if (pkrOrderName.SelectedIndex == 1)
        {
            pkrOrderPrice.SelectedIndex = 0;
            vm.OrdenaPerNomAscendent();
        }
        if (pkrOrderName.SelectedIndex == 2)
        {
            pkrOrderPrice.SelectedIndex = 0;
            vm.OrdenaPerNomDescendent();
        }
    }

    private async void MaterialSeleccionado(object sender, ItemTappedEventArgs e)
    {
        Material mat = e.Item as Material;
        await Shell.Current.GoToAsync($"{nameof(DetallMaterialVIew)}",

            new Dictionary<string, object>
            {
                { "Material", mat }
            }
        );
    }

    private void SearchText(object sender, TextChangedEventArgs e)
    {
        vm.filtra(e.NewTextValue);
    }
}