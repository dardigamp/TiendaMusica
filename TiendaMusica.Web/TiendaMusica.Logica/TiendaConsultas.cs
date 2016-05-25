using System;
using System.Collections.Generic;
using System.Linq;
using TiendaMusica.Data;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Logica.Comun;
using TiendaMusica.Logica.ViewModels;

namespace TiendaMusica.Logica
{
    public class TiendaConsultas
    {
        //private readonly ChinookDominio db;
        private readonly ITiendaMusicaRepository db;
        //public TiendaConsultas()
        //{
        //    db = new ChinookDominio();        
        //}
        public TiendaConsultas(ITiendaMusicaRepository repositorio)
        {
            //db = new EFTiendaMusicaRepository();
            db = repositorio;
        }
        public IEnumerable<AlbumsPorArtistaViewModel> Albums(string nombre)
        {
            String nombreConvertido = Utilidades.TransformarNombre(nombre);

            //return db.Album
            //            .Where(a => a.Artist.Name == nombreConvertido)
            //            .Select(o => new AlbumsPorArtistaViewModel
            //            {
            //                Album = o.Title,
            //                Artista = o.Artist.Name
            //            }).ToList();

            ////usando un ORM
            //return db.Albums.GetAll()
            //            .Where(a => a.Artist.Name == nombreConvertido)
            //            .Select(o => new AlbumsPorArtistaViewModel
            //            {
            //                Album = o.Title,
            //                Artista = o.Artist.Name
            //            }).ToList();

            //usando Insight Database
            return db.ConsultaAdHoc<AlbumsPorArtistaViewModel>("select a.Title Album,b.Name Artista,a.DiscImage DiscImage from [dbo].[Album] a inner join[dbo].[Artist] b ON(a.ArtistId = b.ArtistId) where b.Name = @Name", 
                new { Name = nombreConvertido});

        }

        public AlbumViewModel Album(string nombreAlbum, string nombreArtista)
        {
            String nombreArtistaConv = Utilidades.TransformarNombre(nombreArtista);
           
            //usando Insight Database
            return db.ConsultaAdHoc<AlbumViewModel>("select D.AlbumId AlbumId, D.Title Album, D.DiscImage DiscImage, A.Name Artista  from Album D inner join Artist A ON (D.ArtistId=A.ArtistId) where D.Title= @NameAlbum AND A.Name = @NameArtist",
                new { NameAlbum= nombreAlbum, NameArtist = nombreArtistaConv  }).First();

        }

        public void AlbumUpdate(int idAlbum, string nombreAlbum, string imageAlbum)
        {
            //String nombreArtistaConv = Utilidades.TransformarNombre(nombreArtista);

            //usando Insight Database
            db.ProdAdHoc("UPDATE [dbo].[Album] SET Title = @NameAlbum, DiscImage = @NameDisc WHERE AlbumId= @IdenAlbum",
                new { NameAlbum = nombreAlbum, NameDisc = imageAlbum, IdenAlbum = idAlbum });
            //db.ConsultaAdHoc<AlbumViewModel>("UPDATE [dbo].[Album] SET Title = @NameAlbum, DiscImage = @NameDisc WHERE AlbumId= @IdenAlbum",
            //    new { NameAlbum = nombreAlbum, NameDisc = imageAlbum, IdenAlbum = idAlbum }).;

        }
    }
}