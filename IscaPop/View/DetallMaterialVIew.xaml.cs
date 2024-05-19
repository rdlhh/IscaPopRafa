using IscaPop.Base;
using IscaPop.Model;
using ThreadNetwork;

namespace IscaPop.View;

[QueryProperty(nameof(Material), "Material")]
public partial class DetallMaterialVIew : BasePage
{
	private Material mat;
	public Material Material
	{
		get { return mat; }
		set { SetProperty(ref mat, value); }
	}
	public DetallMaterialVIew()
	{
		InitializeComponent();
	}

    private void btnSolicitar(object sender, EventArgs e)
    {

    }
}