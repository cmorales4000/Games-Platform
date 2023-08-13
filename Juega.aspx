﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Juega.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Juega</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
</head>
<body>
    <div id="nav-placeholder"></div>

    <div class="bg2">

        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-col-lg-12 col-xs-12">
                    <img src="assets/images/pagina3.jpg" class="img-responsive"  style="width:100%" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <p class="text-justify parrafo mgr20T" style="color:#ffffff">
                        <span style="color:#ffffff"><b>RULES</b></span>
                        </br>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Feugiat in fermentum posuere urna nec tincidunt praesent semper. In hac habitasse platea dictumst. Id interdum velit laoreet id donec. Vestibulum lorem sed risus ultricies. Cursus in hac habitasse platea dictumst quisque sagittis. Cras pulvinar mattis nunc sed blandit libero volutpat. Placerat orci nulla pellentesque dignissim enim sit amet venenatis urna. Donec ultrices tincidunt arcu non sodales neque sodales ut. Facilisis magna etiam tempor orci.
                    </p>
                </div>               
            </div>                     
            <%--<div class="row">
                </br>
                <div class="col-md-12 col-sm-col-lg-12 col-xs-12 text-center">
                    <img src="assets/images/paginaweb-09.png" style="width:100%;max-width:300px;" />
                </div>
            </div>--%>

            <div class="row">
                <div class="col-md-12 col-xs-12 text-center">
                    <a href="/Acceder"><img src="assets/images/btnExperiencia.png" class="exp" /></a>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 col-xs-12 text-center">
                    <a href="javascript:;"><img src="assets/images/LOGO.png" class="logo" style="height:200px;"/></a>
                </div>
            </div>
            <br/>
        </div>
        <br />
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
