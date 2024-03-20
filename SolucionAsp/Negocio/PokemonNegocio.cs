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
        public List<Pokemon> listarConId(string id)
        {
            List<Pokemon> listaPoke = new List<Pokemon>();
            accesoDatos conexionDB = new accesoDatos();
            try
            {
                conexionDB.setearConsulta("Select P.Id, P.Numero,P.Nombre, P.Descripcion,P.UrlImagen, E.descripcion as Tipo, D.descripcion as Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id and P.IdDebilidad = D.Id and P.Id = "+ id);
                conexionDB.ejecutarLectura();

                while(conexionDB.Lector.Read())
                {
                    Pokemon pokemonAux = new Pokemon();
                    pokemonAux.Id = (int)conexionDB.Lector["Id"];
                    pokemonAux.Numero = (int)conexionDB.Lector["Numero"];
                    pokemonAux.Nombre = (string)conexionDB.Lector["Nombre"];
                    pokemonAux.Descripcion = (string)conexionDB.Lector["Descripcion"];
                    if (conexionDB.Lector["UrlImagen"] is DBNull)
                    {
                        pokemonAux.urlImagen = "https://i.postimg.cc/52mdzCM6/No-Image-Placeholder-svg.png";
                    }
                    else if (!(conexionDB.Lector["UrlImagen"] is DBNull))
                    {
                        pokemonAux.urlImagen = (string)conexionDB.Lector["UrlImagen"];
                    }
                    pokemonAux.Tipo = new Tipo();
                    pokemonAux.Tipo.DescripcionTipo = (string)conexionDB.Lector["Tipo"];
                    pokemonAux.Debilidad = new Debilidad();
                    pokemonAux.Debilidad.DescripcionDebilidad = (string)conexionDB.Lector["Debilidad"];

                    listaPoke.Add(pokemonAux);
                }
                return listaPoke;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexionDB.cerrarConexion();
            }
        }
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
                    if (datos.Lector["UrlImagen"] is DBNull)
                    {
                        pokeAuxiliar.urlImagen = "https://i.postimg.cc/52mdzCM6/No-Image-Placeholder-svg.png";
                        
                    }else if (!(datos.Lector["UrlImagen"] is DBNull))
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
        
        public void agregarPokemon(Pokemon pokemonNuevo)
        {
            accesoDatos nuevaConexion = new accesoDatos();
            try
            {
                nuevaConexion.setearConsulta("insert into POKEMONS (Numero,Nombre,Descripcion,UrlImagen,IdTipo,IdDebilidad,Activo) values (@Numero,@Nombre,@Descripcion,@UrlImagen,@IdTipo,@IdDebilidad,1)");
                nuevaConexion.setearParametro("@Numero",pokemonNuevo.Numero);
                nuevaConexion.setearParametro("@Nombre", pokemonNuevo.Nombre);
                nuevaConexion.setearParametro("@Descripcion", pokemonNuevo.Descripcion);
                nuevaConexion.setearParametro("@UrlImagen", pokemonNuevo.urlImagen);
                nuevaConexion.setearParametro("@IdTipo", pokemonNuevo.Tipo.Id);
                nuevaConexion.setearParametro("@IdDebilidad", pokemonNuevo.Debilidad.Id);

                nuevaConexion.ejecutarAccion();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                nuevaConexion.cerrarConexion();
            }
        }
    }
}
