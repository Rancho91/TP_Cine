using DataCineDb.Data;
using DataCineDb.Entidades.Factura;
using DataCineDb.Entidades.Maestras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Service
{
    public class serviceFactura
    {

        private DbHelper helper = DbHelper.ObtenerInstancia();
        public void crearFactura(Facturas factura)
        {
            SqlTransaction t = null;
            try
            {
                helper.Conectar(); // Abre la conexión aquí

                List<Parametros> listParametrosFactura = new List<Parametros>();

                listParametrosFactura.Add(new Parametros("@FormaPago", factura.FormaPago.Codigo));
                listParametrosFactura.Add(new Parametros("@codCliente", factura.Cliente.Codigo));
                listParametrosFactura.Add(new Parametros("@TipoFactura", factura.TipoFactura.Codigo));
                listParametrosFactura.Add(new Parametros("@Descuento", factura.Descuento));

                t = helper.ObtenerConexion().BeginTransaction(); // Inicia la transacción después de abrir la conexión

                int nroFactura = helper.InsertarNumeroFactura("SP_Crear_Factura", "@NroFactura", t, listParametrosFactura);

                foreach (Funciones funcion in factura.Funciones)
                {
                    foreach (Butacas butaca in funcion.Butacas)
                    {
                        List<Parametros> listParametrosDetalle = new List<Parametros>();
                        listParametrosDetalle.Add(new Parametros("@butaca", butaca.Codigo));
                        listParametrosDetalle.Add(new Parametros("@funcion", funcion.Codigo));
                        listParametrosDetalle.Add(new Parametros("@precio", funcion.Precio));
                        listParametrosDetalle.Add(new Parametros("@NroFactura", nroFactura));

                        helper.Insertar("sp_crear_detalle_factura", listParametrosDetalle, t);
                    }
                }

                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                Console.Write(ex.Message);
            }
            finally
            {
                helper.Desconectar(); // Cierra la conexión en el bloque finally
            }
        }

    }
}
