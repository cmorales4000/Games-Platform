<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Inicio</title>
    <link rel="icon" type="image/png" href="assets/images/LOGO.png" sizes="16x16"/>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
</head>
<body>
    <!-- Fixed navbar -->
    <div id="nav-placeholder"></div>

    
    <!-- Carousel
    ================================================== -->
    <div class="bg">

        <div class="container">

            <div>
                                

            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner" role="listbox">
                    <%--<div class="item active">
                        <img class="first-slide" src="/assets/images/bannerUnico.jpg" alt="First slide">
                    </div>--%>
                    <div class="item active">
                        <img class="first-slide" src="/assets/images/banner1.jpg" alt="First slide">
                    </div>
                    <div class="item">
                        <img class="first-slide" src="/assets/images/banner2.jpg" alt="First slide">
                    </div>
                    <div class="item">
                        <img class="first-slide" src="/assets/images/banner3.jpg" alt="First slide">
                    </div>
                </div>
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
            <!-- /.carousel -->

            <div class="row">
                <div class="col-md-12 text-center">
                    <a href="/Acceder"><img src="assets/images/btnExperiencia.png" class="exp"/></a>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 col-xs-12 text-center">
                    <img src="assets/images/LOGO.png" class="logo" style="height:200px;" />
                </div>
            </div>
            <br/>
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
