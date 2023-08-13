<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="_Reportes" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Reportes</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
</head>
<body>
    <div id="nav-placeholder"></div>

    <div class="bg2">

    <div id="nav-placeholder2"></div>

        

        <div class="col-md-12 col-xs-12 text-center" id="divfin" runat="server" visible="false" style="color:#ffffff;font-size:20px;padding-top:10px;">
			 <b>FELICITACIONES,  COMPLETASTE EL CONGRESO CLICC</b> </br> 
             Ahora estás puedes girar nuestra ruleta
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-8 col-xs-12 col-md-offset-2 mgr20T">

                <!-- Nav tabs -->
                <ul class="col-md-12 col-xs-12 nav" role="tablist">
                    <li role="presentation" class="col-md-6 col-xs-6 active text-center"><a href="#porVisitar" aria-controls="visitados" style="color:#145CA2 ;" role="tab" data-toggle="tab"><img src="assets/images/porVisitar.png" class="text-center" style="width:100%;max-width:240px;" /></a></li>
                    <li role="presentation"  class="col-md-6 col-xs-6 text-center"><a href="#visitados" aria-controls="visitados" style="color:#145CA2 ;" role="tab" data-toggle="tab"><img src="assets/images/visitados.png" class="text-center" style="width:100%;max-width:240px;" /></a></li>
                </ul>
                 

                <!-- Tab panes -->
                <div class="tab-content">
                    <div role="tabpanel" class="tab-pane active" id="porVisitar" style="color:#ffffff" runat="server">
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4"></div>
                            <div class="col-md-4"></div>
                        </div>
                    </div>
                    <div role="tabpanel" class="tab-pane" id="visitados" style="color:#ffffff" runat="server">

                    </div>
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
            $("#nav-placeholder").load("nav.html");
        });
        $(function () {
            $("#nav-placeholder2").load("nav2.html");
        });
    </script>
</body>
</html>
