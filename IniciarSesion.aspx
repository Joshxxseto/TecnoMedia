<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="TecnoMedia.IniciarSesion" %>

<!DOCTYPE html>
<html lang="en" id="principal" >

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/normalize.css">
    <title>TecnoMedia</title>
</head>

<body>
    <header class="site-header">
        <div class="contenedor">
            <div class="barra">
               <h1 class="no-margin"><span>TecnoMedia</span></h1>
            </div>
        </div>
    </header>

    <main class="contenedor">
        <h2 class="text-center">Iniciar Sesión</h2>
        <div class="grid centrar-columnas">
            <div class="columnas-12">
                <img src="img/contacto.jpg" class="Imagen-Blogs">
            </div>

            <div class="formulario-contacto columnas-10">
                <form runat="server">
                    <div class="campo">
                        <label for="email">E-mail</label>
                        <asp:TextBox runat="server" ID="EmailInput" placeholder="E-mail"></asp:TextBox>
                    </div>
                    <div class="campo">
                        <label >Contraseña</label>
                         <asp:TextBox runat="server" ID="PassInput" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <div class="campo enviar ">
                        <asp:Button ID="Iniciar" CssClass="boton boton-primario" runat="server" text="Iniciar" OnClick="Inciar_Click"></asp:Button>
                         <asp:HyperLink Id="NavLink2" text="Registrarse" CssClass="boton boton-primario" name="Registrar" runat="server"  NavigateUrl="~/Registrarse.aspx">
                         </asp:HyperLink>
                    </div>
                </form>
            </div>
        </div>
    </main>
    <script src="js/main.js"></script>
</body>

</html>
