using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataCineDb.Data
{
    public class DbHelper
    {
        private SqlConnection conexion;
        private string stringconexion = @"Data Source=DESKTOP-1G25HFQ;Initial Catalog=COMPLEJO_CINE;Integrated Security=True";
        private static DbHelper instancia;

        private DbHelper()
        {
                
            conexion = new SqlConnection("Data Source=DESKTOP-1G25HFQ;Initial Catalog=COMPLEJO_CINE;Integrated Security=True");

           
        }

        public SqlConnection ObtenerConexion()
        {
            return this.conexion;
        }

        public static DbHelper ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new DbHelper();
            }
            return instancia;
        }

        public void Conectar()
        {
            conexion.Open();
        }
        public void Desconectar()
        {
            conexion.Close();
        }

        public DataTable Consultar(string nombreSp)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSp;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            Desconectar();
            return dt;
        }

        internal DataTable Consultar(string nombreSp, List<Parametros> lstParametros)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSp;
            foreach (Parametros p in lstParametros)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            Desconectar();
            return dt;

        }
    }
}
