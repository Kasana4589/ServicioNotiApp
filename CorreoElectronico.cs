/// <summary>
/// Tipo de notificación: Correo electrónico
/// </summary>
public class CorreoElectronico: Notificacion
{

    private string? _asunto;
    private double _archivosAdjuntos;
    private string? _CC_CCO;

    public string? Asunto //Si el asunto es null, por defecto se escribe "Sin cuerpo"
    {
        get => _asunto;
        private set {
            if (string.IsNullOrWhiteSpace(value)) 
               _asunto = "Sin cuerpo";
        if (value.Length >50) throw new ArgumentOutOfRangeException("La caracteres del asunto no pueden ser mayor a 50.");
        _asunto = value;
        }
    }
    public double ArchivosAdjuntos //Los archivos adjuntos no pueden superar el peso de 2MB
    {
        get => _archivosAdjuntos;
        private set {
          if (value < 0 || value > 25) throw new ArgumentOutOfRangeException("Lo archivos adjuntos no puden tener más de 25 mb");
          _archivosAdjuntos = value;
        }
    }

    public string? CC_CCO //Si CC_CCO es null, por defecto el valor es "CC"
    {
        get => _CC_CCO;
        private set
        {
           
            if (string.IsNullOrWhiteSpace(value))
            {
                _CC_CCO = "CC";
               
            }
            else
            {
               _CC_CCO = value;
            }
        }
    }
    public CorreoElectronico(string mensaje, string destinatario, string asunto, double archivosAdjuntos, string cc_cco) : base(mensaje, destinatario)
    {
        Asunto = asunto;
        ArchivosAdjuntos= archivosAdjuntos;
        CC_CCO = cc_cco;
    }
    protected override void Validar()
    {
        if (string.IsNullOrWhiteSpace(Mensaje))
            throw new ArgumentException("El mensaje no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(Destinatario))
            throw new ArgumentException("El destinatario no puede estar vacío.");
    }
    protected override void Preparar()
    {
        Console.WriteLine("Preparando notificación...");
    }
    protected override void EnviarReal()
    {

    }
    protected override void Finalizar()
    {
        Estado = EstadoNotificacion.Enviado;
        FechaEnvio = DateTime.Now;
        Console.WriteLine("Notificación enviada con éxito.");
    }
    public override string ImprimirInformacion()
    {
        return $@"----- NOTIFICACIÓN -----
 Asunto: {Asunto}
 Es: {CC_CCO}
 Mensaje: {Mensaje}
 Destinatario: {Destinatario}
 Estado: {Estado}
 Fecha de envío: {FechaEnvio}
 Tamaño archivos adjuntos: {ArchivosAdjuntos}";
         
    }
}