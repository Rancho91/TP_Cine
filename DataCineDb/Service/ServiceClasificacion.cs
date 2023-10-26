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
    public class ServiceClasificacion
    {
        DbHelper helper = DbHelper.ObtenerInstancia();

        public List<Clasificaciones> getClasificaciones()
        {
            List<Clasificaciones> clasificaciones = new List<Clasificaciones>();
            DataTable dt = helper.Consultar("sp_get_clasificaciones");
            foreach (DataRow dr in dt.Rows)
            {
                clasificaciones.Add(new Clasificaciones(dr["Descripcion"].ToString(), (int)dr["cod_clasificacion"]));
            }
            return clasificaciones;
        }
    }
}
