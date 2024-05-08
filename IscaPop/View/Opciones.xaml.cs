using IscaPop.Base;

namespace IscaPop.View;

public partial class Opciones : BasePage
{
    public Opciones()
    {
        InitializeComponent();
    }

    private async void RegistrarseClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(Login)}");
    }

    private async void IniciarSesionClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(IniciarSesionView)}");
    }
}