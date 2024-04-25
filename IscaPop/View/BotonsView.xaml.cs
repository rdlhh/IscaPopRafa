using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

public partial class BotonsView : ContentPage
{
    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { organisme = value; vm.AssignaDades(Organisme); }
    }

    private BotonsVM vm;
	public BotonsView()
	{
		InitializeComponent();
        BindingContext = vm = new BotonsVM();
	}

    private async void BtnPerfil(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(OrganismeView)}",

            new Dictionary<string, object>
            {
                { "Organisme", Organisme }
            }
        );
    }

    private void BtnMaterial(object sender, EventArgs e)
    {

    }

    private void BtnBuscar(object sender, EventArgs e)
    {

    }
}