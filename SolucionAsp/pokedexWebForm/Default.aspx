<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedexWebForm.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido a pokedex 2024</h1>
    <p>aca van a estar los pokemons</p>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--
            <%
    foreach (var item in (List<Dominio.Pokemon>)Session["listaPokemon"])
    {

%>


<div class="col">
    <div class="card">
        <img src="<%: item.urlImagen %>" class="card-img-top" alt="...">
        <div class="card-body">
            <h5 class="card-title"><%:item.Nombre%></h5>
            <p class="card-text"><%: item.Descripcion %></p>
        </div>
    </div>
</div>
<%} %>

        --%>


        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>

                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("urlImagen")%>" class="card-img-top" alt="..." />

                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
</asp:Content>

