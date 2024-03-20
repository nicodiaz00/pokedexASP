using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listarTipo()
        {
            List<Tipo> listaTipo = new List<Tipo>();
            accesoDatos accesoDatos = new accesoDatos();
            try
            {
                accesoDatos.setearConsulta("Select Id, Descripcion from ELEMENTOS");
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Tipo auxiliar = new Tipo();
                    auxiliar.Id = (int)accesoDatos.Lector["Id"];
                    auxiliar.DescripcionTipo = (string)accesoDatos.Lector["Descripcion"];

                    listaTipo.Add(auxiliar);
                }
                return listaTipo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
