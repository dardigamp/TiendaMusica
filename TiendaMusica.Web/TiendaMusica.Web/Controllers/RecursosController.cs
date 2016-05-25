using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TiendaMusica.Web.Controllers
{
    public class RecursosController: Controller
    {
        public FileResult Mostrar(string id, string ext)
        {
            var path = Path.Combine(Server.MapPath("~/Imagen/Album"), id + $"{ext}");
            
            return new FileStreamResult(new FileStream(path, FileMode.Open), MimeMapping.GetMimeMapping($"{id}{ext}"));
        }
    }
}
