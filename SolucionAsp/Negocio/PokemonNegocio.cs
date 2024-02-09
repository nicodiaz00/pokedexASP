using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listarPokemon()
        {
            List<Pokemon> list = new List<Pokemon>();
            accesoDatos datos = new accesoDatos();

            try
            {
                datos.setearConsulta("Select P.Id, P.Numero,P.Nombre, P.Descripcion,P.UrlImagen, E.descripcion as Tipo, D.descripcion as Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id and P.IdDebilidad = D.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pokemon pokeAuxiliar = new Pokemon();
                    pokeAuxiliar.Id = (int)datos.Lector["Id"];
                    pokeAuxiliar.Numero = (int)datos.Lector["Numero"];
                    pokeAuxiliar.Nombre = (string)datos.Lector["Nombre"];
                    pokeAuxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        pokeAuxiliar.urlImagen = (string)datos.Lector["UrlImagen"];
                    }
                    pokeAuxiliar.Tipo = new Tipo();
                    pokeAuxiliar.Tipo.DescripcionTipo = (string)datos.Lector["Tipo"];
                    pokeAuxiliar.Debilidad = new Debilidad();
                    pokeAuxiliar.Debilidad.DescripcionDebilidad = (string)datos.Lector["Debilidad"];

                    list.Add(pokeAuxiliar);

                    
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
