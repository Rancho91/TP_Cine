using DataCineDb.Data;
using DataCineDb.Entidades;
using DataCineDb.Entidades.Maestras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Service
{
    public class ServicePeliculas
    {
        DbHelper helper = DbHelper.ObtenerInstancia();
        public List<Peliculas> GetPeliculas()
        {
            DataTable dt = helper.Consultar("SP_GET_TODAS_PELICULAS");
            List<Peliculas> peliculas = new List<Peliculas>();

            foreach (DataRow row in dt.Rows)
            {
                peliculas.Add(
                    new Peliculas(
                         (int)row[0],
                        row[2].ToString(),
                       new Generos( row[1].ToString()),
                       new Clasificaciones( row[4].ToString()),
                       new Paises( row[3].ToString()),                 
                       TimeSpan.Parse( row[5].ToString())
                        ));
            }
            return peliculas;
        }
    }
}
