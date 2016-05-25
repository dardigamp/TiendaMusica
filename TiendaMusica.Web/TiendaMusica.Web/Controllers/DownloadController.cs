
using System.Web.Mvc;
using TiendaMusica.Logica;

namespace TiendaMusica.Web.Controllers
{
    public class DownloadController : Controller
    {
        public ActionResult Reporte()
        {
            string archivoExcel = new ReporteSimple().Reporte();
            FilePathResult download = new FilePathResult(archivoExcel, "application/vnd.ms-excel");
            download.FileDownloadName = "Reporte_2016.xls";

            return download;
        }

        public ActionResult Descargar(string id)
        {
            string archivo = new ReporteSimple().Obtener(id);
            FilePathResult download = new FilePathResult(archivo, "application/" + id);
            download.FileDownloadName = "Documento." + id;
            return download;
        }
    }
}
