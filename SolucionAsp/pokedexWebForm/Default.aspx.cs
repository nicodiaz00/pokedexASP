﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedexWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {   
           
           
           
            if (!IsPostBack)
            {
                PokemonNegocio pokeNegocio = new PokemonNegocio();
                ListaPokemon = pokeNegocio.listarPokemon();
                repetidor.DataSource = ListaPokemon;
                repetidor.DataBind();
            }
        }
    }
}