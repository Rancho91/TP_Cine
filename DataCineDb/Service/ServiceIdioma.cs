using DataCineDb.Data;
using DataCineDb.Entidades.Auxiliares;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Service
{
    public class ServiceIdioma 
    {
        DbHelper helper = DbHelper.ObtenerInstancia();
        public  List<Idiomas> GetIdiomas()
        {
            List<Idiomas> list = new List<Idiomas> ();
            DataTable dt = helper.Consultar("SP_GET_IDIOMAS");

            foreach(DataRow row in dt.Rows)
            {
                list.Add(new Idiomas(row[1].ToString(), (int)row[0]));
            }
            
            return new List<Idiomas>();
        }

    }
}
