using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedexWebForm
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            
            
            try
            {
                
                
                if (!IsPostBack)
                {
                    TipoNegocio tipoNegocio = new TipoNegocio();
                    List<Tipo> listaDetipos = tipoNegocio.listarTipo();
                    ddlTIPO.DataSource = listaDetipos;
                    ddlTIPO.DataTextField = "DescripcionTipo";
                    ddlTIPO.DataValueField = "Id";

                    DebilidadNegocio debilidadNegocio = new DebilidadNegocio();
                    List<Debilidad> listaDebilidad = debilidadNegocio.listarDebilidad();
                    ddlDEBILIDAD.DataSource = listaDebilidad;
                    ddlDEBILIDAD.DataTextField = "DescripcionDebilidad";
                    ddlDEBILIDAD.DataValueField = "Id";
                    
                    ddlTIPO.DataBind();
                    ddlDEBILIDAD.DataBind();
                    
                    

                }
                if (Request.QueryString["id"] != null)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    List<Pokemon> listado = negocio.listarConId(Request.QueryString["id"].ToString());
                    Pokemon seleccionado = listado[0];

                    txtID.Text = Request.QueryString["id"].ToString();
                    txtNOMBRE.Text = seleccionado.Nombre;
                    txtNUMERO.Text = seleccionado.Numero.ToString();
                    txtDESCRIPCION.Text = seleccionado.Descripcion;
                    

                    //precargar campos del formulario
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
                //posteriormente iremos a una pantalla de error
            }

        }

        protected void btnENVIAR_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon nuevoPoke = new Pokemon();
                
                nuevoPoke.Nombre = txtNOMBRE.Text;
                nuevoPoke.Numero = int.Parse(txtNUMERO.Text);
                nuevoPoke.Descripcion = txtDESCRIPCION.Text;
                nuevoPoke.urlImagen = txtIMAGEN.Text;

                nuevoPoke.Tipo = new Tipo();
                nuevoPoke.Tipo.Id = int.Parse(ddlTIPO.SelectedValue);

                nuevoPoke.Debilidad = new Debilidad();
                nuevoPoke.Debilidad.Id = int.Parse(ddlDEBILIDAD.SelectedValue);

                negocio.agregarPokemon(nuevoPoke);
                Response.Redirect("listaPokemon.aspx", false);
                


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }

        }

        protected void txtIMAGEN_TextChanged(object sender, EventArgs e)
        {
            campoImg.ImageUrl= txtIMAGEN.Text;
        }
    }
}