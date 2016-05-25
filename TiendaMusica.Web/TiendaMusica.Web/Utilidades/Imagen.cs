using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMusica.Web.Utilidades
{
    internal class Imagen
    {
        public Imagen(Stream imagen, string archivo, string contentType, string rutaServidor)
        {
            this.Bytes = imagen;
            this.NombreArchivo = archivo;
            this.TipoContenido = contentType;
            this.Ruta = rutaServidor;
        }

        public Stream Bytes { get; private set; }
        public string NombreArchivo { get; private set; }
        public string Ruta { get; private set; }
        public string TipoContenido { get; private set; }

        public void Grabar(string nombre, string thumbNailPath)
        {
            GuardarArchivoOriginal(nombre);
            GuardarThumbnail(nombre, thumbNailPath);
        }

        private void GuardarThumbnail(string nombre, string thumbNailPath)
        {
            string thumbnailNombre = "thumbnail_" + nombre;
            using (var image = Image.FromFile(Path.Combine(Ruta, nombre)))
            {
                var escala = Math.Min((float)200 / image.Width, (float)200 / image.Height);
                var scalaWidth = (int)(image.Width * escala);
                var scalaHeight = (int)(image.Height * escala);

                using (var thumbnail = image.GetThumbnailImage(scalaWidth, scalaHeight, null, IntPtr.Zero))
                {
                    thumbnail.Save(Path.Combine(thumbNailPath, thumbnailNombre));
                }
            }
            //return Path.Combine(thumbNailPath, thumbnailNombre);
        }

        private void GuardarArchivoOriginal(string nombre)
        {
            //if (File.Exists(Path.Combine(Ruta, nombre)))
            //{
            //    throw new InvalidOperationException("El archivo ya existe");
            //}
            FileStream fs = new FileStream(Path.Combine(Ruta, nombre), FileMode.Create);
            Bytes.Position = 0;
            Bytes.CopyTo(fs);
            fs.Position = 0;
            fs.Flush();
            fs.Close();
        }
    }
}
