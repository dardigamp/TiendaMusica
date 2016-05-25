using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Dominio;

namespace TiendaMusica.Data.EF.RepositoriosEntidades
{
    class AlbumRepository :  GenericRepository<EFTiendaMusicaRepository, Album>
    {
        public AlbumRepository(EFTiendaMusicaRepository contexto) : base(contexto)
        {

        }
    }
}
