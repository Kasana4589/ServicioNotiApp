
Notificacion[] notificaciones =
{
 new CorreoElectronico("Hola, Buenos días", "Luis", "Saludo", 0, "CCO"),
 new CorreoElectronico("Trabajo de historia", "Manuel", "", 24, ""),
 //new CorreoElectronico("", "", "", 26, "") Datos Incorrectos
 new Sms("Hola, ¿cómo estás?", "1234567890")
 

};


foreach (Notificacion noti in notificaciones)
{
    noti.ProcesarEnvio(); 

    MostrarInformacion(noti);
    Console.WriteLine();
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

    else if (noti is Sms)
        Console.WriteLine("Es un mensaje SMS");
}

Console.ReadKey();