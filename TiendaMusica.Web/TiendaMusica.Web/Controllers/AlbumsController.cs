using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TiendaMusica.Infraestructura;
using TiendaMusica.Logica;
using TiendaMusica.Logica.ViewModels;
using TiendaMusica.Web.Utilidades;

namespace TiendaMusica.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly TiendaConsultas tienda;
        public AlbumsController()
        {
            tienda = ConstructorServicios.TiendaConsultas();
        }
        public ActionResult Editar(string nombreArtista, string nombreAlbum)
        {
            AlbumViewModel album = tienda.Album(nombreAlbum, nombreArtista);
            return View(album);
        }

        [HttpPost]
        public ActionResult Editar(HttpPostedFileBase archivo, AlbumViewModel model)
        {
            string nombreArchivo = archivo == null ? model.DiscImage: model.Album + Path.GetExtension(archivo.FileName);
            //actualizar BD
            tienda.AlbumUpdate(model.AlbumId, model.Album, nombreArchivo);
            if (archivo != null)
            {
                GrabarImagen(archivo, nombreArchivo);                
            }
            
            return RedirectToAction("Editar", "Albums", new { nombreArtista= model.Artista , nombreAlbum = model.Album });
            //return Redirect("/admin/{model.Artista}/{model.Album}/Editar");
            //return RedirectToRoute("Albums", new { controller = "Albums", action = "Editar", nombreArtista = model.Artista, nombreAlbum = model.Album });
            //string url = $"/admin/{model.Artista}/{model.Album}/Editar";
            //return RedirectPermanent(url);
            //return RedirectToRoute(new { controller = "Albums", action = "Editar", nombreArtista = model.Artista, nombreAlbum = model.Album });
        }

        private void GrabarImagen(HttpPostedFileBase archivo, string nombreArchivo)
        {
            MemoryStream ms = new MemoryStream();
            archivo.InputStream.CopyTo(ms);
            Imagen imagen = new Imagen(ms, archivo.FileName, archivo.ContentType, Server.MapPath("~/Imagen/Album"));
            imagen.Grabar(nombreArchivo, Server.MapPath("~/Imagen/Album/ThumbNail"));
        }

        private bool EsImagen(string contentType)
        {
            return contentType.Contains("image");
        }
    }
}
