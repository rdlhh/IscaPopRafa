using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "Organisme")]
public partial class OrganismeView : ContentPage
{
	private Organisme organisme;
	public Organisme Organisme
	{
		get { return organisme;  }
		set { organisme = value; }
	}
	private OrganismeVM vm;
	public OrganismeView()
	{
		InitializeComponent();
	}

    private void BtnGuardar(object sender, EventArgs e)
    {

    }

    private void BtnEsborrar(object sender, EventArgs e)
    {

    }

    private void BtnNou(object sender, EventArgs e)
    {

    }
}