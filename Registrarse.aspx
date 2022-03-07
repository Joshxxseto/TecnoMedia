<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TecnoMedia.Registrarse" %>

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
               <h1 class="no-margin">TecnoMedia<span>TecnoMedia</span></h1>
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
                        <label >Nombre</label>
                         <asp:TextBox runat="server" ID="NombreInput" placeholder="Nombre de Usuario"></asp:TextBox>
                    </div>
                    <div class="campo">
                        <label for="email">E-mail</label>
                        <asp:TextBox runat="server" ID="EmailInput" placeholder="E-mail"></asp:TextBox>
                    </div>
                    <div class="campo">
                        <label >Contraseña</label>
                         <asp:TextBox runat="server" ID="PassInput" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    </div>
                    <div class="campo">
                        <label >Imagen</label>
                         <asp:FileUpload runat="server" ID="FileInput"/>
                    </div>
                    <div class="campo enviar ">
                         <asp:Button runat="server" CssClass="boton boton-primario" text="Registrarse" OnClick="Registrar_Click" ></asp:Button>
                         <asp:HyperLink Id="NavLink2" text="Iniciar Sesión" CssClass="boton boton-primario" name="Iniciar" runat="server"  NavigateUrl="~/IniciarSesion.aspx">
                         </asp:HyperLink>
                    </div>
                </form>
            </div>
        </div>
    </main>
    <script src="js/main.js"></script>
</body>

</html>