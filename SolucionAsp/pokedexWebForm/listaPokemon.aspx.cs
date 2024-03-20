using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedexWebForm
{
    public partial class listaPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaPokemon"] == null)
            {
                PokemonNegocio pokeNegocio = new PokemonNegocio();
                Session.Add("listaPokemon", pokeNegocio.listarPokemon());
            }
            dgvPokemons.DataSource = Session["listaPokemon"];
            dgvPokemons.DataBind();
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idPoke = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id="+ idPoke);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }
    }
}