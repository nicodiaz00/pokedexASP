using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class accesoDatos
    {
        //dentro de esta clase voy a setear todas las funciones que me permitan agregar, consultar borrar etc.
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }


        public accesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database= POKEDEX_DB; integrated security= true");
            comando = new SqlCommand();
        }
        
        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
                conexion.Close();
            }
        }
        public void setearParametro(string clave, object valor)
        {
            comando.Parameters.AddWithValue(clave, valor);
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
