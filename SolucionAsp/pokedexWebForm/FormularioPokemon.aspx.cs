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
                //configuracion inicial
                
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
                /*
                if (Request.QueryString["id"] != null) //aca valido si viene un ID
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    //parte nnueva que estoy agregando(creo los elementos tipo y debilidad)
                    TipoNegocio TipoPoke = new TipoNegocio();
                    List<Tipo> listTIpos =TipoPoke.listarTipo();
                    ddlTIPO.DataSource= listTIpos;
                    ddlTIPO.DataTextField = "DescripcionTipo";
                    ddlTIPO.DataValueField= "Id";
                    

                    DebilidadNegocio debilidadPoke  = new DebilidadNegocio();
                    List<Debilidad> listadoDebilidad = debilidadPoke.listarDebilidad();
                    ddlDEBILIDAD.DataSource= listadoDebilidad;
                    ddlDEBILIDAD.DataTextField = "DescripcionDebilidad";
                    ddlDEBILIDAD.DataValueField = "Id";

                    ddlTIPO.DataBind();
                    ddlDEBILIDAD.DataBind();


                    List<Pokemon> listado = negocio.listarConId(Request.QueryString["id"].ToString()); 
                    Pokemon seleccionado = listado[0]; //aca esta el pokemon que nace del listar

                    txtID.Text = Request.QueryString["id"].ToString();
                    
                    txtNOMBRE.Text = seleccionado.Nombre;
                    txtNUMERO.Text = seleccionado.Numero.ToString();
                    txtDESCRIPCION.Text = seleccionado.Descripcion;
                    txtIMAGEN.Text = seleccionado.urlImagen;
                    ddlTIPO.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDEBILIDAD.SelectedValue=seleccionado.Debilidad.Id.ToString();
                    

                    

                    txtIMAGEN_TextChanged(sender, e);
                
                    //precargar campos del formulario
                }
                */

                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    List<Pokemon> listado = negocio.listarPokemon(Request.QueryString["id"]);
                    Pokemon seleccion = listado[0];

                    //precargamos campos
                    txtID.Text = Request.QueryString["id"];
                    txtNOMBRE.Text = seleccion.Nombre;
                    txtNUMERO.Text = seleccion.Numero.ToString();
                    txtDESCRIPCION.Text = seleccion.Descripcion;
                    txtIMAGEN.Text = seleccion.urlImagen;

                    ddlTIPO.SelectedValue = seleccion.Tipo.Id.ToString();

                    ddlDEBILIDAD.SelectedValue = seleccion.Debilidad.Id.ToString();
                    txtIMAGEN_TextChanged(sender, e);



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


                if (Request.QueryString["id"]!=null) 
                {
                    //aca deberiamos poner el modificarpokemon
                    nuevoPoke.Id = int.Parse(txtID.Text);
                    negocio.modificarPokemon(nuevoPoke);
                    
                }
                else
                {
                    negocio.agregarPokemon(nuevoPoke);
                }
                


                Response.Redirect("listaPokemon.aspx", false);
                


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        protected void txtIMAGEN_TextChanged(object sender, EventArgs e)
        {
            campoImg.ImageUrl= txtIMAGEN.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}