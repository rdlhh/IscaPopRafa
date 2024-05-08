using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "Organisme")]
public partial class BotonsView : BasePage
{
    private BotonsVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }
    public BotonsView()
    {
        InitializeComponent();
        BindingContext = vm = new BotonsVM();
        vm.assignDades(Organisme);

    }

    private async void PerfilClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(OrganismeView)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme }
             }
            );
    }

    private async void PublicarMaterialClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(MaterialView)}",
             new Dictionary<string, object>
             {
                 { "OrganismeSelected", Organisme }
             }
            );
    }

    private void BuscarClick(object sender, EventArgs e)
    {
    }
}