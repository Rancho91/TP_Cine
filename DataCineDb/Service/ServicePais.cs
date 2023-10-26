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
    public class ServicePais
    {
        DbHelper helper = DbHelper.ObtenerInstancia();
        public List<Paises> GetPaises()
        {
            DataTable dt = helper.Consultar("sp_get_Paises");
            List<Paises> paises = new List<Paises>();

            foreach (DataRow row in dt.Rows)
            {
                paises.Add(new Paises(row["descripcion"].ToString(), (int)row["cod_pais"]));
            }
            return paises;
        }
    }
}
