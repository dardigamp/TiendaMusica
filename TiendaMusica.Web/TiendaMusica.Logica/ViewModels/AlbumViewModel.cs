using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaMusica.Logica.ViewModels
{
    public class AlbumViewModel
    {
        public int AlbumId { get; set; }        
        public string Album { get; set; }
        public string DiscImage { get; set; }
        public string Artista { get; set; }
    }
}
