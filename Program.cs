
Notificacion[] notificaciones =
{
 new CorreoElectronico("Hola, Buenos días", "Luis", "Saludo", 0, "CCO"),
 new CorreoElectronico("Trabajo de historia", "Manuel", "", 24, "")
 //new CorreoElectronico("", "", "", 26, "") Datos Incorrectos
};

foreach (Notificacion noti in notificaciones)
{
    MostrarInformacion(noti);
    Console.WriteLine();
    DescribirTipo(noti);
    Console.WriteLine(new string('-', 40));

}
void MostrarInformacion(Notificacion noti)
{
    Console.WriteLine(noti.ImprimirInformacion());
}
void DescribirTipo(Notificacion noti)
{
    Console.WriteLine($"Tipo real (GetType): {noti.GetType().Name}");

    if (noti is CorreoElectronico)
        Console.WriteLine("Es por correo electrónico");
   
}

Console.ReadKey();