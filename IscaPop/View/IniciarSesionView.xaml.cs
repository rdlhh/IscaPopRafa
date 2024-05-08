using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;

namespace IscaPop.View;

public partial class IniciarSesionView : BasePage
{
    private IniciarSesionVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDades(Organisme); }
    }
    public IniciarSesionView()
    {
        InitializeComponent();
        BindingContext = vm = new IniciarSesionVM();
    }

    private async void EntrarClick(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string contraseña = txtContraseña.Text;
        Organisme = vm.buscarCuenta(email, contraseña);
        if (organisme == null)
        {
            DisplayAlert("Cuenta no encontrada", "Los valores introducidos no coindicen con ningún usuario", "OK");
        }
        else
        {
            await Shell.Current.GoToAsync($"{nameof(BotonsView)}",
                 new Dictionary<string, object>
                 {

                     { "Organisme", Organisme }
                 }
                );
        }
    }
}