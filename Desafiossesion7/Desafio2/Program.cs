using System;

public interface INotificable
{
    void Notificar();
}

public class NotificacionEmail : INotificable
{
    public string DireccionCorreo { get; set; }

    public NotificacionEmail(string direccionCorreo)
    {
        DireccionCorreo = direccionCorreo;
    }

    public void Notificar()
    {
        Console.WriteLine("Enviando notificación por correo electrónico a: " + DireccionCorreo);
    }
}

public class NotificacionWhatsapp : INotificable
{
    public string NumeroTelefono { get; set; }

    public NotificacionWhatsapp(string numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;
    }

    public void Notificar()
    {
        Console.WriteLine("Enviando notificación por WhatsApp al número: " + NumeroTelefono);
    }
}

public class NotificacionSMS : INotificable
{
    public string NumeroTelefono { get; set; }

    public NotificacionSMS(string numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;
    }

    public void Notificar()
    {
        Console.WriteLine("Enviando notificación por SMS al número: " + NumeroTelefono);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la dirección de correo electrónico:");
        string email = Console.ReadLine();
        INotificable emailNotificacion = new NotificacionEmail(email);

        Console.WriteLine("Ingrese el número de teléfono para WhatsApp:");
        string numeroWhatsapp = Console.ReadLine();
        INotificable whatsappNotificacion = new NotificacionWhatsapp(numeroWhatsapp);

        Console.WriteLine("Ingrese el número de teléfono para SMS:");
        string numeroSMS = Console.ReadLine();
        INotificable smsNotificacion = new NotificacionSMS(numeroSMS);

        emailNotificacion.Notificar();
        whatsappNotificacion.Notificar();
        smsNotificacion.Notificar();
    }
}
