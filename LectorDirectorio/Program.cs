using archivo;
string pathGuardar = @"C:\Users\jbust\Documents\taller1\tp9\tl1-tp9-2026-julianbustospondal\LectorDirectorio";
string? path;
int repetir = 1;
do
{
    Console.WriteLine("Ingrese la ruta del directorio a la que desea acceder:");
    path = Console.ReadLine();
    if (!Directory.Exists(path))
    {
        Console.WriteLine("La ruta ingresada no existe.");
    }
    else
    {
        repetir = 0;
    }
} while (repetir == 1);
String[] Carpetas = Directory.GetDirectories(path);
String[] Archivos = Directory.GetFiles(path);
List<InfoArchivo> infoArchivos = new List<InfoArchivo>();
foreach (string archivo in Archivos)
{
    FileInfo info = new FileInfo(archivo);
    InfoArchivo infoArchivo = new InfoArchivo();
    infoArchivo.Nombre = info.Name;
    infoArchivo.Tamaño = info.Length;
    infoArchivo.FechaModificacion = info.LastWriteTime;
    infoArchivos.Add(infoArchivo);
}
Console.WriteLine("Carpetas:");
foreach (string carpeta in Carpetas)
{
    Console.WriteLine(carpeta);
}
Console.WriteLine("Archivos:");
string outputFile = Path.Combine(pathGuardar, "reporte_archivos.csv");
using (StreamWriter sw = new StreamWriter(outputFile, false))
{
    foreach (InfoArchivo infoArchivo in infoArchivos)
    {
        double tamañoKb = infoArchivo.Tamaño / 1024.0;
        Console.WriteLine($"Nombre: {infoArchivo.Nombre}, Tamaño: {tamañoKb:F2} KB, Fecha: {infoArchivo.FechaModificacion}");
        sw.WriteLine($"Nombre: {infoArchivo.Nombre}, Tamaño: {tamañoKb:F2} KB, Fecha: {infoArchivo.FechaModificacion}");
    }
}
