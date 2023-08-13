<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MiCuenta.aspx.cs" Inherits="_MiCuenta" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Mi Cuenta</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
</head>
<body>
    <div id="nav-placeholder"></div>

    <div class="bg2">

        <%--<div class="container">
            <div class="row">
                <div class="col-md-3 col-sm-col-lg-3 col-xs-3 text-center" style="background-color:#DF7D14;padding:15px 0px;">
                    <a href="/MiCuenta" style="color:#ffffff;" class="subMenu">Mis datos</a>
                </div>
                <div class="col-md-3 col-sm-col-lg-3 col-xs-3 text-center" style="background-color:#DF7D14;padding:15px 0px;">
                    <a href="/Juego2" style="color:#ffffff;" class="subMenu">Juego</a>
                </div>
                <div class="col-md-3 col-sm-col-lg-3 col-xs-3 text-center" style="background-color:#DF7D14;padding:15px 0px;">
                    <a href="/Reportes" style="color:#ffffff;" class="subMenu">Reportes</a>
                </div>
                <div class="col-md-3 col-sm-col-lg-3 col-xs-3 text-center" style="background-color:#DF7D14;padding:15px 0px;">
                    <a href="/Logout" style="color:#ffffff;" class="subMenu">Salir</a>
                </div>
            </div>
        </div>--%>

        <div id="nav-placeholder2"></div> 

        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2" id="dvDataContacto">
                    
                </div>
            </div>
            <div class="row">
                <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2 text-center">
                    <a href="javascript:;" onclick="editData();" class="btn" style="background-color:#DF7D14;color:#ffffff;">Editar</a>
                </div>
            </div>
        </div>
        </br>
    </div>

    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div style="margin-top:20px;">
                        <a href="https://google.com" target="_blank">&copy; 2023 - Footer</a>
                    </div>
                </div>
            </div>
        </div>
    </footer>
    


    <script src="<%=Page.ResolveUrl("~") %>assets/js/jquery.min.js"></script>
    <script src="<%=Page.ResolveUrl("~") %>assets/js/bootstrap.min.js"></script>
    <script src="<%=Page.ResolveUrl("~") %>assets/js/jquery.funciones.min.js"></script>
    <script>
        $(function () {
            $("#nav-placeholder").load("nav.html");
        });
        $(function () {
            $("#nav-placeholder2").load("nav2.html");
        });
    </script>
    <script type="text/javascript">
        $(function () {
            loadData();
        });
        var loadData = function () {
            ajaxSend('/ajax/FormMiCuenta_ajax', { accion: "0" }, 'dvDataContacto', function () { });
        }
        var editData = function () {
            abrirDialogo('/ajax/FormMiCuenta_ajax', { accion: "1" }, function () { }, 'modal-sm');
        }
    </script>
</body>
</html>
