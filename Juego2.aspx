<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Juego2.aspx.cs" Inherits="_Juego2" %>

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
                    <div id="dvMsgRta" style="color:#ffffff" runat="server"></div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1 mgr20T">
                    <%--<img src="assets/images/rompecabezas.jpg" style="width:800px;" />--%>
                    <div style="margin-left:" id="dvContenedor">
                        <img src="assets/images/PIRATAS.png" id="imgRompecabezas" usemap="#image-map">
                        <map name="image-map" id="imageMap" runat="server">
<area target="" alt="" title="" href="" coords="303,476,74" shape="circle">
<area target="" alt="" title="" href="" coords="329,616,80" shape="circle">
<area target="" alt="" title="" href="" coords="487,539,81" shape="circle">
<area target="" alt="" title="" href="" coords="651,575,74" shape="circle">
<area target="" alt="" title="" href="" coords="801,625,85" shape="circle">
<area target="" alt="" title="" href="" coords="681,718,81" shape="circle">
<area target="" alt="" title="" href="" coords="507,786,74" shape="circle">
<area target="" alt="" title="" href="" coords="637,864,73" shape="circle">
<area target="" alt="" title="" href="" coords="784,909,74" shape="circle">
<area target="" alt="" title="" href="" coords="864,1013,77" shape="circle">
<area target="" alt="" title="" href="" coords="736,1095,79" shape="circle">
<area target="" alt="" title="" href="" coords="601,1172,84" shape="circle">
<area target="" alt="" title="" href="" coords="640,1336,81" shape="circle">
<area target="" alt="" title="" href="" coords="628,1471,79" shape="circle">
<area target="" alt="" title="" href="" coords="801,1628,146" shape="circle">
                            
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
                fillColor: '006A88',
                fillOpacity: 0.98,
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
