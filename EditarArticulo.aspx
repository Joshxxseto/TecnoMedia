<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarArticulo.aspx.cs" Inherits="TecnoMedia.EditarArticulo" MasterPageFile="~/Maestra.Master" %>

<asp:Content ID="VerArticulo" runat="server" ContentPlaceHolderID="ContenidoMaestro">
     <main class="contenedor">
        <div class="articulo-new">
            <h1>Editar Articulo</h1>
            <form runat="server">
                <asp:TextBox id=tituloArea runat="server" placeholder="Titulo del Articulo" TextMode="SingleLine"></asp:TextBox>
                <asp:TextBox ID="textArea" TextMode="MultiLine" Columns="100" Rows="10" runat="server"  placeholder="Escribe el Articulo"></asp:TextBox>
                <label for="file">Imagen del Articulo</label>
                <asp:FileUpload runat="server" ID="FileInput"/>
                <asp:Button id="finalizarBtn" class="boton boton-primario" Text="Finalizar" runat="server" OnClick="Actualizar_Click"/>
            </form>
        </div>
    </main>
</asp:Content>