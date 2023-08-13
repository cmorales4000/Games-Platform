<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="_ErrorPage" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Lo sentimos</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
</head>
<body>
    <div id="nav-placeholder"></div>

    <!-- Carousel
    ================================================== -->
    <div class="bg2">

        <div class="container">
            <div class="row">
                <div class="col-md-col-lg-12 text-center">
                    <h1>Uppss, Ocurrio un error</h1>
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
    </script>
</body>
</html>
