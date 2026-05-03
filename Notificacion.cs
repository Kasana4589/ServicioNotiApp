public abstract class Notificacion
{
    private string? _mensaje;
    private string? _destinatario;

    /// <summary>
    ///     Esto controla que la notificación solo pueda acceder a ciertos estados durante su ciclo de vida, 
    ///     lo que ayuda a mantener la integridad del proceso de envío, asi no se realizan errores como 
    ///     estado=liquido o cualquier tipo de broma que entropezca la funcionalidad del proyecto.
    /// </summary>
    public enum EstadoNotificacion
    {
        Pendiente,
        Preparando,
        Enviando,
        Enviado,
        Error
    }


    public EstadoNotificacion Estado { get; protected set; } = EstadoNotificacion.Pendiente;
    public DateTime FechaEnvio { get; protected set; }
    protected Notificacion(string? mensaje, string? destinatario)
    {
        Mensaje = mensaje;
        Destinatario = destinatario;
    }

    public string Mensaje
    {
        get => _mensaje ?? string.Empty;
        private set => _mensaje = string.IsNullOrWhiteSpace(value) ? throw new
            ArgumentException("El mensaje no puede estar vacío.") : value;
    }

    public string Destinatario
    {
        get => _destinatario ?? string.Empty;
        private set => _destinatario = string.IsNullOrWhiteSpace(value) ? throw new
            ArgumentException("El destinatario no puede estar vacío.") : value;
    }

    public void ProcesarEnvio()
    {
        try
        {
            Estado = EstadoNotificacion.Preparando;
            Validar();

            Preparar();

            Estado = EstadoNotificacion.Enviando;
            EnviarReal();

            Finalizar();
        }
        catch (Exception ex)
        {
            Estado = EstadoNotificacion.Error;
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
        Estado = EstadoNotificacion.Enviado;
        FechaEnvio = DateTime.UtcNow;
        Console.WriteLine("Notificación enviada con éxito.");
    }
    public bool FueExitosa()
    {
        return Estado == EstadoNotificacion.Enviado;
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

