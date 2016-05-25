using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMusica.Data.InsightDB;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Logica;

namespace TiendaMusica.Infraestructura
{
    public class ConstructorServicios
    {
        public static TiendaConsultas TiendaConsultas()
        {
            //ORM
            //return new TiendaConsultas(new EFTiendaMusicaRepository());

            //Insight Database
            return new TiendaConsultas(new TiendaMusicaDB("ChinookDominio"));
        }
    }
}
