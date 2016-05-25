using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMusica.Logica
{
    public class ReporteSimple
    {
        public String Reporte()
        {
            HSSFWorkbook libro = new HSSFWorkbook();
            var hoja = libro.CreateSheet("Ejemplo reporte");
            var fila = hoja.CreateRow(1);
            var celda = fila.CreateCell(1);

            celda.SetCellValue("Reporte de ejemplo");

            var fila3 = hoja.CreateRow(3);
            for (int i = 3; i <=6; i++)
            {
                var filan = hoja.CreateRow(i);
                var celda1 = filan.CreateCell(1);
                celda1.SetCellValue($"Presentacion del Proyecto Final del curso alumno {i}");
                celda1.CellStyle.WrapText = true;
                var celda2 = filan.CreateCell(2);
                celda2.SetCellValue(DateTime.Now.AddDays(i).ToLongDateString());
            }
            var nombreArchivo = NombreArchivo();
            var fileStream = new FileStream(nombreArchivo, FileMode.CreateNew);
            libro.Write(fileStream);
            fileStream.Flush();
            fileStream.Close();
            return nombreArchivo;
        }

        public string Obtener(string ext)
        {
            //var fileStream = new FileStream(@"C:\Downloads\Mapping.pdf", FileMode.Open, FileAccess.Read);
            //var reader = new StreamReader(fileStream);
            //return reader;
            string nombreArchivo = String.Empty;
            DirectoryInfo di = new DirectoryInfo(@"C:\Downloads");
            foreach (var fi in di.GetFiles("*."+ ext))
            {
                nombreArchivo = fi.Name;
            }
            return @"C:\Downloads\"+ nombreArchivo;
        }

        private string NombreArchivo()
        {
            var ruta = Path.GetTempFileName();
            File.Delete(ruta);
            return Path.ChangeExtension(ruta, "xls");
        }
    }
}
