<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="listaPokemon.aspx.cs" Inherits="pokedexWebForm.listaPokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col">
        <asp:GridView runat="server" CssClass="table" DataKeyNames="Id" ID="dgvPokemons" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="NUMERO" DataField="Numero" />
                <asp:BoundField HeaderText="NOMBRE" DataField="Nombre" />
                <asp:BoundField HeaderText="DESCRIPCION" DataField="Descripcion" />
                <asp:BoundField HeaderText="IMAGEN" DataField="urlImagen" />
                <asp:BoundField HeaderText="TIPO" DataField="Tipo.DescripcionTipo" />
                <asp:BoundField HeaderText="DEBILIDAD" DataField="Debilidad.DescripcionDebilidad" />
            </Columns>
            <%-- 
                    <asp:BoundField HeaderText="ID" DataField="Id" />
                    <asp:BoundField HeaderText="NUMERO" DataField="Numero" />
                    <asp:BoundField HeaderText="NOMBRE" DataField="Nombre" />
                    <asp:BoundField HeaderText="DESCRIPCION" DataField="Descripcion" />
                    <asp:BoundField HeaderText="IMAGEN" DataField="urlImagen" />
                    <asp:BoundField HeaderText="TIPO" DataField="Tipo" />
                    <asp:BoundField HeaderText="DEBILIDAD" DataField="Debilidad" />--%>
        </asp:GridView>
    </div>

</div>
</asp:Content>
