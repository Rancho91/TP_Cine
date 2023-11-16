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
        private string stringconexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=COMPLEJO_CINE;Integrated Security=True";
        private static DbHelper ?instancia;

        private DbHelper()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-1G25HFQ;Initial Catalog=COMPLEJO_CINE;Integrated Security=True");

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

        public void Insertar(string sp, List<Parametros> param, SqlTransaction t)
        {
            SqlCommand cmd = new SqlCommand(sp, conexion, t);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (Parametros p in param)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            cmd.ExecuteNonQuery();
            
        }
        public void Insertar(string sp, List<Parametros> param )
        {
            try
            {
        Conectar();
            SqlCommand cmd = new SqlCommand(sp, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (Parametros p in param)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
            }
            cmd.ExecuteNonQuery();
            Desconectar();
            }
            finally
            {
                Desconectar();
            }
    
        }
        public int InsertarNumeroFactura(string sp, string param, SqlTransaction t, List<Parametros> parametros)
        {
   
            SqlCommand cmd = new SqlCommand(sp, conexion,t);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter parameter = new SqlParameter(param, SqlDbType.Int);
            parameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(parameter);
            foreach (Parametros p in parametros)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
            }            
          

            cmd.ExecuteNonQuery();
            int nroFactura = (int)parameter.Value;
            return nroFactura;
        }

    }
}
