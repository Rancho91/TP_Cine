using DataCineDb.Data;
using DataCineDb.Entidades;
using DataCineDb.Entidades.Factura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Service
{
    public class ServiceFormasPago
    {
        DbHelper helper = DbHelper.ObtenerInstancia();
        public List<FormasPagos> GetFormasPagos()
        {
            DataTable dt = helper.Consultar("SP_GET_FORMA_PAGO");
            List<FormasPagos> formasPagos = new List<FormasPagos>();

            foreach (DataRow row in dt.Rows)
            {
                formasPagos.Add(new FormasPagos( (int)row["cod_forma_pago"], row["Forma_pago"].ToString()) );
            }
            return formasPagos;
        }
    }
}
