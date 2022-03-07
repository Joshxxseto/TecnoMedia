<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TecnoMedia.Inicio" MasterPageFile="~/Maestra.Master" %>

<asp:Content ID="InicioContenido" runat="server" ContentPlaceHolderID="ContenidoMaestro">
    <div class="contenido-principal contenedor">
        <main class="blog">
            <h2>Artículos</h2>
            <form runat="server">
<asp:Panel ID="ListaArticulos" runat="server"></asp:Panel>
            </form> 
        </main>
    </div>
</asp:Content>