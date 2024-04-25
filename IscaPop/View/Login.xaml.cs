using System.Net.Mail;
using System.Net;
using System.Text;

namespace IscaPop.View;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void OnGetVerificationCodeClicked(object sender, EventArgs e)
    {
        // Generar código de verificación aleatorio
        string verificationCode = GenerateVerificationCode();

        // Correo electrónico del destinatario
        string email = EmailEntry.Text;

        // Enviar correo electrónico con el código de verificación
        SendVerificationEmail(email, verificationCode);

        DisplayAlert("Código de verificación enviado", "Se ha enviado un código de verificación a tu dirección de correo electrónico.", "OK");
    }

    private string GenerateVerificationCode()
    {
        // Generar un código de 6 dígitos
        Random random = new Random();
        int code = random.Next(100000, 999999);
        return code.ToString();
    }

    private void SendVerificationEmail(string toEmail, string verificationCode)
    {
        // Configurar cliente SMTP
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("rdlhh87@gmail.com", "qhem sdbu agxa zgda"),
            EnableSsl = true,
        };

        // Crear mensaje de correo electrónico
        var message = new MailMessage
        {
            From = new MailAddress("pruebasproyectos123456@gmail.com"),
            Subject = "Código de verificación",
            Body = $"Tu código de verificación es: {verificationCode}",
            BodyEncoding = Encoding.UTF8,
            IsBodyHtml = true,
        };

        // Añadir destinatario
        message.To.Add(toEmail);

        try
        {
            // Enviar correo electrónico
            smtpClient.Send(message);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}