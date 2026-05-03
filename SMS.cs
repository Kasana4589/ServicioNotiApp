/// <summary>
/// Tipo de notificación: Mensaje SMS
/// </summary>
public class Sms : Notificacion
{
    // Atributos encapsulados
    private string? _numeroTelefono;
    private int _longitudMaxima;

    /// <summary>
    /// Número telefónico del destinatario
    /// Debe contener solo números y tener entre 10 y 15 dígitos
    /// </summary>
    public string NumeroTelefono
    {
        get => _numeroTelefono ?? string.Empty;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El número de teléfono no puede estar vacío.");

            // Validación: solo números
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                    throw new ArgumentException("El número solo debe contener dígitos.");
            }

            // Validación: longitud típica de SMS
            if (value.Length < 10 || value.Length > 15)
                throw new ArgumentOutOfRangeException("El número debe tener entre 10 y 15 dígitos.");

            _numeroTelefono = value;
        }
    }

    /// <summary>
    /// Longitud máxima del mensaje SMS (por estándar 160 caracteres)
    /// </summary>
    public int LongitudMaxima
    {
        get => _longitudMaxima;
        private set
        {
            if (value <= 0 || value > 160)
                throw new ArgumentOutOfRangeException("La longitud máxima no puede ser mayor a 160 caracteres.");

            _longitudMaxima = value;
        }
    }

    /// <summary>
    /// Constructor del SMS
    /// </summary>
    public Sms(string mensaje, string numeroTelefono)
      : base(mensaje, numeroTelefono)
    {
        NumeroTelefono = numeroTelefono;
        LongitudMaxima = 160;
    }
    protected override void Validar()
    {
        base.Validar();
        if (Mensaje.Length > LongitudMaxima)
            throw new ArgumentException($"El mensaje no puede exceder los {LongitudMaxima} caracteres.");
    }
    protected override void EnviarReal()
    {
        // Simulación de envío de SMS
        Console.WriteLine($"Enviando SMS a {NumeroTelefono}: {Mensaje}");
    }
    protected override void Finalizar()
    {
        base.Finalizar();
        Console.WriteLine("SMS enviado con éxito.");
    }

    public override string ImprimirInformacion()
    {
        return $@"----- SMS -----
Mensaje: {Mensaje}
Número: {NumeroTelefono}
Estado: {Estado}
Fecha de envío: {FechaEnvio}
Longitud máxima: {LongitudMaxima}";
    }
}