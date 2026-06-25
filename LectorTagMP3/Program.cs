using System.IO;
using System.Text;
Console.WriteLine("introduzca la ruta de su cancion");
string? rutaCancion = Console.ReadLine();


if (string.IsNullOrWhiteSpace(rutaCancion) || !File.Exists(rutaCancion))
{
    Console.WriteLine("El archivo no existe.");
}
else
{
    using (FileStream fs = new FileStream(rutaCancion, FileMode.Open))
    {
        Encoding enc = Encoding.GetEncoding("latin1");
        fs.Seek(-128, SeekOrigin.End);

        byte[] buffer = new byte[128];
        fs.Read(buffer, 0, 128);
        string identificador = enc.GetString(buffer, 0, 3);
        if (identificador != "TAG")
        {
            Console.WriteLine("Esta canción no contiene etiquetas ID3v1.");

        }
        else
        {
            string titulo = enc.GetString(buffer, 3, 30).TrimEnd('\0');
            string artista = enc.GetString(buffer, 33, 30).TrimEnd('\0');
            string album = enc.GetString(buffer, 63, 30).TrimEnd('\0');
            string año = enc.GetString(buffer, 93, 4).TrimEnd('\0');

            Console.WriteLine($"Título: {titulo}");
            Console.WriteLine($"Artista: {artista}");
            Console.WriteLine($"Álbum: {album}");
            Console.WriteLine($"Año: {año}");
        }
    }
}