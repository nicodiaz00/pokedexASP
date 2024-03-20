using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DebilidadNegocio
    {
        public List<Debilidad> listarDebilidad()
        {
            List<Debilidad> listaDebilidad = new List<Debilidad>();
            accesoDatos conexionDatos = new accesoDatos();
            try
            {
                conexionDatos.setearConsulta("Select Id, Descripcion from ELEMENTOS");
                conexionDatos.ejecutarLectura();

                while(conexionDatos.Lector.Read())
                {
                    Debilidad auxDebilidad = new Debilidad();
                    auxDebilidad.Id = (int)conexionDatos.Lector["Id"];
                    auxDebilidad.DescripcionDebilidad = (string)conexionDatos.Lector["Descripcion"];
                    listaDebilidad.Add(auxDebilidad);
                }
                return listaDebilidad;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDatos.cerrarConexion();
            }
        }
    }
}
