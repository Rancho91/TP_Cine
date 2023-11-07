using DataCineDb.Data;
using DataCineDb.Entidades.Auxiliares;
using DataCineDb.Entidades.Maestras;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCineDb.Service
{
    public class ServiceFunciones
    {
        DbHelper helper = DbHelper.ObtenerInstancia();
        public List<Funciones> getFunciones()
        {
            List<Funciones> funciones = new List<Funciones>();
            DataTable dt = helper.Consultar("SP_GET_TODAS_FUNCIONES");
                foreach (DataRow row in dt.Rows)
            {
            
                funciones.Add(
                new Funciones(
                (int)row[0],
                 new Peliculas(row[1].ToString()),
                DateTime.Parse(row[3].ToString()),
                TimeSpan.Parse(row[2].ToString()),
                (decimal)row[7],
                (bool)row[6],
                (bool)row[5],
                new Idiomas(row[8].ToString())

                    ));

            }
            return funciones;
        }
        public Funciones getFuncionesButacas(int codFuncion)
        {
            Funciones funcion = new Funciones();
            funcion.Codigo = codFuncion;
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("@cod_funcion", codFuncion));
            DataTable dt = helper.Consultar("SP_FUNCIONES_BUTACAS", parametros);
            foreach (DataRow row in dt.Rows)
            {
                bool vendida = false;
                if (row[5] != DBNull.Value)
                {
                    vendida = (bool)row[5];
                }
                funcion.agregarButaca(
                new Butacas(
                    (int)row[0],
                     row[2].ToString(),
                     (int)row[3],
                     vendida,
                    false
              )

                    );

            }
            return funcion;
        }

        public void postFunciones(Salas sala)
        {
            
                foreach (Funciones funcion in sala.Funciones)
                {
                    List<Parametros> listParametros = new List<Parametros>();
                    listParametros.Add(new Parametros("@Cod_pelicula", funcion.Pelicula.Codigo));
                    listParametros.Add(new Parametros("@Cod_sala", sala.Codigo));
                    listParametros.Add(new Parametros("@Horario", funcion.Horario));
                    listParametros.Add(new Parametros("@terceraDimencion", funcion.TerceraDimencion));
                    listParametros.Add(new Parametros("@subtitulos", funcion.Subtitulada));
                listParametros.Add(new Parametros("@fecha", funcion.Fecha));
                    listParametros.Add(new Parametros("@Precio", funcion.Precio));
                    listParametros.Add(new Parametros("@Cod_idioma", funcion.Idioma.Codigo));
                    helper.Insertar("SP_FUNCIONES_INSERT", listParametros);
                }
             
          
            


        }
    }
}
