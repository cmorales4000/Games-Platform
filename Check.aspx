<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Check.aspx.cs" Inherits="_Check" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Verificar</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
    <style type="text/css">
        h2{
            padding:50px 0px;background-color: #FFFFFF;color: #27313A;
        }
    </style>
</head>
<body>
    <nav class="navbar navbar-default navbar-fixed-top">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/"><img src="/assets/images/LOGONAV.png" style="height:80px;" /></a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-right">
                <li><a href="/Evento" class="menuSup">YOUR<br />PAGE 1</a></li>
                <li><img src="/assets/images/palito.jpg" class="separador" /></li>
                <li><a href="/ComoGanar" class="menuSup">YOUR<br />PAGE 2</a></li>
                <li><img src="/assets/images/palito.jpg" class="separador" /></li>
                <li><a href="/Juega" class="menuSup">YOUR<br />PAGE 3</a></li>
                <li><img src="/assets/images/palito.jpg" class="separador" /></li>
                <li><a href="/Acceder" class="menuSup"><img src="/assets/images/miCuenta.png" style="height:40px;" /></a></li>
        </div>
        <!--/.nav-collapse -->
    </div>
</nav>

    
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <div id="dvMsgRta" runat="server"></div>
                </div>
            </div>
        </div>
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
            $("#nav-placeholder").load("/nav.html");
        });
    </script>
</body>
</html>
