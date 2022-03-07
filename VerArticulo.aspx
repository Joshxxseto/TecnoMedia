<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerArticulo.aspx.cs" Inherits="TecnoMedia.VerArticulo" MasterPageFile="~/Maestra.Master" %>

<asp:Content ID="VerArticulo" runat="server" ContentPlaceHolderID="ContenidoMaestro">
     <main class="contenedor">
        <asp:Panel ID="Articulo" runat="server"></asp:Panel>
         <form runat="server">
            <div id="Comentarios" runat="server" class=comentarios>
            <h2>Comentarios</h2>
            <div  class="boton-comentario">
                <asp:TextBox ID="textarea" TextMode="MultiLine" Columns="100" Rows="5" runat="server"  placeholder="Comenta tu opinion"></asp:TextBox>
                <asp:Button runat="server" CssClass="boton boton-primario" OnClick="Comentar_Click" Text="Comentar"/>
            </div>
            </div>
             </form>
    </main>
</asp:Content>
