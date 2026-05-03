public abstract class Notificacion
{
    private string? _mensaje;
    private string? _destinatario;



    public string Estado { get; protected set; } //pendiente
    public DateTime FechaEnvio { get; protected set; }
    protected Notificacion(string? mensaje, string? destinatario)
    {
        _mensaje = mensaje;
        _destinatario = destinatario;
    }

    public string Mensaje
    {
        get => _mensaje ?? string.Empty;
        private set => _mensaje = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("El mensaje no puede estar vacío.") : value;
    }

    public string Destinatario
    {
        get => _destinatario ?? string.Empty;
        private set => _destinatario = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("El destinatario no puede estar vacío.") : value;
    }

    public void ProcesarEnvio()
    {
        try
        {
            Validar();
            Preparar();
            EnviarReal();
            Finalizar();
        }
        catch (Exception ex)
        {
            Estado = "Error";
            Console.WriteLine($"Error al enviar: {ex.Message}");
        }
    }
    protected virtual void Validar()
    {
        if (string.IsNullOrWhiteSpace(Mensaje))
            throw new ArgumentException("El mensaje no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(Destinatario))
            throw new ArgumentException("El destinatario no puede estar vacío.");
    }
    protected virtual void Preparar()
    {
        Console.WriteLine("Preparando notificación...");
    }
    protected abstract void EnviarReal();
    protected virtual void Finalizar()
    {
        Estado = "Enviado";
        FechaEnvio = DateTime.Now;
        Console.WriteLine("Notificación enviada con éxito.");
    }
    public virtual string ImprimirInformacion()
    {
        return $@"----- NOTIFICACIÓN -----
Mensaje: {Mensaje}
Destinatario: {Destinatario}
Estado: {Estado}
Fecha de envío: {FechaEnvio}";
    }
}

