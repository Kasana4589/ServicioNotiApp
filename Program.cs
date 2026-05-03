/// <summary>
///Camila Alejadra Barrios Arias
///Heidy Nahiry Rodriguez
///Dánniel Diaz Condega
///Jazmin Anthonela Escoto Espinoza
///Jesly Hassiel Escoto Pineda
/// <summary>

List<Notificacion> lista = new List<Notificacion>();

AgregarNotificacion(lista, () => new CorreoElectronico("Tarea", "Ron123@gmail.com", "", 26, "")); //Dato Incorrecto
AgregarNotificacion(lista,() => new CorreoElectronico("Hola, Buenos días", "NicoRob@gmail.com", "Saludo", 0, "CCO"));
AgregarNotificacion(lista,() => new CorreoElectronico("Trabajo de historia", "LuzMaría@hotmail.com", "", 24, ""));
AgregarNotificacion(lista,() => new SMS("Hola, ¿cómo estás?", "1234567890"));

foreach (Notificacion noti in lista)
{
    noti.ProcesarEnvio();
    Console.WriteLine();

    MostrarInformacion(noti);
    DescribirTipo(noti);

    Console.WriteLine(new string('-', 40));
}
void MostrarInformacion(Notificacion noti)
{
  
        Console.WriteLine(noti.ImprimirInformacion());
        Console.WriteLine($"Fecha de envío: {noti.FechaEnvio}");
        Console.WriteLine($"Estado final: {noti.Estado}");
    
}
void DescribirTipo(Notificacion noti)
{
    Console.WriteLine($"Tipo real (GetType): {noti.GetType().Name}");

    if (noti is CorreoElectronico)
        Console.WriteLine("Es por correo electrónico");

    else if (noti is SMS)
        Console.WriteLine("Es un mensaje SMS");
}
static void AgregarNotificacion(List<Notificacion> lista, Func<Notificacion> datos)
{
    try
    {
        lista.Add(datos());
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Protección activa: {ex.Message}");
        Console.ResetColor();
        Console.WriteLine();
    }
}

Console.ReadKey();