using DataCineDb.Data;
using DataCineDb.Entidades;
using DataCineDb.Entidades.Auxiliares;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Service
{
    public class ServiceGenero
    {
        DbHelper helper = DbHelper.ObtenerInstancia();
        public List<Generos> GetGeneros()
        {
            DataTable dt = helper.Consultar("sp_get_Generos");
            List<Generos> generos = new List<Generos>();

        foreach (DataRow row in dt.Rows) {
                generos.Add(new Generos(row["descripcion"].ToString(), (int)row["cod_genero"]));
            }
            return generos;
        }
    }
}
