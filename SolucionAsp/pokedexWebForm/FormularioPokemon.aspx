<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="pokedexWebForm.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-8">
                    <div class="mb-3">
                        <label for="txtId" class="form-label">ID</label>
                        <asp:TextBox runat="server" ID="txtID" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNOMBRE" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtNumero" class="form-label">Numero</label>
                        <asp:TextBox runat="server" ID="txtNUMERO" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripcion</label>
                        <asp:TextBox runat="server" ID="txtDESCRIPCION" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="ddlTipo" class="form-label">Tipo</label>
                        <asp:DropDownList ID="ddlTIPO" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="ddlDebilidad" class="form-label">Debilidad</label>
                        <asp:DropDownList ID="ddlDEBILIDAD" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>


                </div>
                <div class="col-4">
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">Imagen</label>
                        <asp:TextBox runat="server" ID="txtIMAGEN" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtIMAGEN_TextChanged"></asp:TextBox>
                        <asp:Image ImageUrl="https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg" ID="campoImg" runat="server" Width="60%" />

                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnENVIAR" runat="server" Text="Enviar" OnClick="btnENVIAR_Click" />
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
