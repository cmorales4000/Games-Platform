<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Juego1.aspx.cs" Inherits="_Juego1" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Juego</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
</head>
<body>
    <div id="nav-placeholder"></div>    

    <div class="bg2">

        <div id="nav-placeholder2"></div>  

        
        <div class="row">
            <div class="col-md-12">
                <%--<p class="text-justify parrafo mgr20T" style="text-align:center">
                    <span><b>EL EVENTO HA TERMINADO, GRACIAS POR PARTICIPAR</b></span>
                </p>--%>
            </div>
            <div class="col-md-12 col-xs-12 text-center" id="divfin" runat="server" visible="false">
                    <div id="dvMsgRta" runat="server"></div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1 mgr20T">
                    <%--<img src="assets/images/rompecabezas.jpg" style="width:800px;" />--%>
                    <div style="margin-left:" id="dvContenedor">
                        <img src="assets/images/ROMPECABEZAS.jpg" id="imgRompecabezas" usemap="#image-map">
                        <map name="image-map" id="imageMap" runat="server">
                            <area target="" alt="" title="" href="" coords="0,180,240,0" shape="rect">
                            <area target="" alt="" title="" href="" coords="240,180,480,0" shape="rect">
                            <area target="" alt="" title="" href="" coords="480,180,720,0" shape="rect">
                            <area target="" alt="" title="" href="" coords="720,180,960,0" shape="rect">
                            <area target="" alt="" title="" href="" coords="960,180,1200,0" shape="rect">
                            <area target="" alt="" title="" href="" coords="1200,180,1440,0" shape="rect">
                            <area target="" alt="" title="" href="" coords="1440,180,1680,0" shape="rect">
                            <area target="" alt="" title="" href="" coords="1680,180,1920,0" shape="rect">

                            <area target="" alt="" title="" href="" coords="0,360,240,180" shape="rect">
                            <area target="" alt="" title="" href="" coords="240,360,480,180" shape="rect">
                            <area target="" alt="" title="" href="" coords="480,360,720,180" shape="rect">
                            <area target="" alt="" title="" href="" coords="720,360,960,180" shape="rect">
                            <area target="" alt="" title="" href="" coords="960,360,1200,180" shape="rect">
                            <area target="" alt="" title="" href="" coords="1200,360,1440,180" shape="rect">
                            <area target="" alt="" title="" href="" coords="1440,360,1680,180" shape="rect">
                            <area target="" alt="" title="" href="" coords="1680,360,1920,180" shape="rect">

                            <area target="" alt="" title="" href="" coords="0,540,240,360" shape="rect">
                            <area target="" alt="" title="" href="" coords="240,540,480,360" shape="rect">
                            <area target="" alt="" title="" href="" coords="480,540,720,360" shape="rect">
                            <area target="" alt="" title="" href="" coords="720,540,960,360" shape="rect">
                            <area target="" alt="" title="" href="" coords="960,540,1200,360" shape="rect">
                            <area target="" alt="" title="" href="" coords="1200,540,1440,360" shape="rect">
                            <area target="" alt="" title="" href="" coords="1440,540,1680,360" shape="rect">
                            <area target="" alt="" title="" href="" coords="1680,540,1920,360" shape="rect">

                            <area target="" alt="" title="" href="" coords="0,720,240,540" shape="rect">
                            <area target="" alt="" title="" href="" coords="240,720,480,540" shape="rect">
                            <area target="" alt="" title="" href="" coords="480,720,720,540" shape="rect">
                            <area target="" alt="" title="" href="" coords="720,720,960,540" shape="rect">
                            <area target="" alt="" title="" href="" coords="960,720,1200,540" shape="rect">
                            <area target="" alt="" title="" href="" coords="1200,720,1440,540" shape="rect">
                            <area target="" alt="" title="" href="" coords="1440,720,1680,540" shape="rect">
                            <area target="" alt="" title="" href="" coords="1680,720,1920,540" shape="rect">

                            <area target="" alt="" title="" href="" coords="0,900,240,720" shape="rect">
                            <area target="" alt="" title="" href="" coords="240,900,480,720" shape="rect">
                            <area target="" alt="" title="" href="" coords="480,900,720,720" shape="rect">
                            <area target="" alt="" title="" href="" coords="720,900,960,720" shape="rect">
                            <area target="" alt="" title="" href="" coords="960,900,1200,720" shape="rect">
                            <area target="" alt="" title="" href="" coords="1200,900,1440,720" shape="rect">
                            <area target="" alt="" title="" href="" coords="1440,900,1680,720" shape="rect">
                            <area target="" alt="" title="" href="" coords="1680,900,1920,720" shape="rect">

                            <area target="" alt="" title="" href="" coords="0,1080,240,900" shape="rect">
                            <area target="" alt="" title="" href="" coords="240,1080,480,900" shape="rect">
                            <area target="" alt="" title="" href="" coords="480,1080,720,900" shape="rect">
                            <area target="" alt="" title="" href="" coords="720,1080,960,900" shape="rect">
                            <area target="" alt="" title="" href="" coords="960,1080,1200,900" shape="rect">
                            <area target="" alt="" title="" href="" coords="1200,1080,1920,900" shape="rect">
                            
                        </map>
                    </div>
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
    <script src="<%=Page.ResolveUrl("~") %>assets/js/jquery.maphilight.min.js"></script>
    
    <script type="text/javascript">
        
        //$(document).ready(function() {
        //    var cords = $('.area').attr('coords').split(',');
        //    $('.areafull').attr('style', 'left:'+cords[0]+'px; top:'+cords[1]+'px; width:'+ (cords[2]-cords[0]) +'px; height:'+ (cords[3]-cords[1]) +'px')
        //});

        $(function () {
            $('#imgRompecabezas').maphilight({
                fade: true,
                fill: true,
                fillColor: '000000',
                fillOpacity: 0.80,
                strokeColor: 'FFFFFF',
                alwaysOn:true
            });
            var width = parseInt($('body').width());
            var height = parseInt($('body').height());
            if (width < 576) {
                $('#dvContenedor').css({ 'width': width - 30 });
                $('#dvContenedor').css({ 'overflow': 'auto' });
                if (height > 580) {
                    $('#dvContenedor').css({ 'height': 580 });
                }
            }
        });
    </script>
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
