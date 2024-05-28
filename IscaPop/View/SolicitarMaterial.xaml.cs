using IscaPop.Base;
using IscaPop.Model;
using IscaPop.ViewModel;
using System.Net.Mail;
using System.Net;

namespace IscaPop.View;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
[QueryProperty(nameof(Material), "MaterialSelected")]
public partial class SolicitarMaterial : BasePage
{
	private SolicitarMaterialVM vm;

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
        set { SetProperty(ref material, value); vm.assignDadesMaterial(material); }
    }

    private Solicitud solicitud;
    public Solicitud Solicitud
    {
        get { return solicitud; }
        set { SetProperty(ref solicitud, value); vm.assignDades(solicitud); }
    }
    public SolicitarMaterial()
	{
		InitializeComponent();
        BindingContext = vm = new SolicitarMaterialVM();
        vm.assignDadesOrganisme(Organisme);
        vm.assignDades(Solicitud);
        vm.assignDadesMaterial(Material);
    }

    private void SolicitarClick(object sender, EventArgs e)
    {
        int cantidad = Convert.ToInt32(txtCantidad.Text);
        DateTime momento = DateTime.Now;
        Solicitud sol = new Solicitud();
        sol.cantidad = cantidad;
        sol.momento = momento;
        sol.organisme = Organisme;
        sol.material = Material;
        Solicitud = sol;
        vm.insertSolicitud(Solicitud);
        Material.stock = Material.stock - Convert.ToInt32(txtCantidad.Text);
        vm.modificarMaterial();
        enviarCorreoElectronico();
    }

    private void enviarCorreoElectronico()
    {
        string email = Material.organisme.email;
        string emailPedido = Organisme.email;
        MailAddress addresFrom = new MailAddress("rdlhh87@gmail.com", "Codi_Verificació");
        MailAddress addresTo = new MailAddress(email);
        MailMessage message = new MailMessage(addresFrom, addresTo);

        message.Subject = "Sol·licitud de material";
        message.IsBodyHtml = true;
        message.Body = "L'organisme amb compte de correu: " + emailPedido + " ha sol·licitat " + Solicitud.cantidad + " unitats del material" +
    material.nom;

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("rdlhh87@gmail.com", "qhem sdbu agxa zgda");

        try
        {
            smtpClient.Send(message);
            DisplayAlert("Sol·licitud realitzada", "La sol·licitud s'ha realitzat correctament", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error en la sol·licitud", "Ha ocorregut un error al sol·licitar el material", "OK");
        }

    }
}