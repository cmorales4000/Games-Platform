<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sorteo1.aspx.cs" Inherits="_sorteo1" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Sorteo</title>

    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/plugins/jQuery-SlotMachine/dist/jquery.slotmachine.css" />
    <style type="text/css">
        body {
            background-image: url('/sorteo/assets/images/background.png');
        }
        #lstGanadores {
            height: 300px;
            width:100%;
            overflow: hidden;
            display: inline-block;
            text-align: center;
            font-size: 100px;
            position: absolute;
            left: 10px;
            top: 625px;
            color: black;
        }
    </style>
</head>
<body>
    <audio controls autoplay loop id="audioId" style="display:none;">
        <source src="/sorteo/assets/media/cassinosong.ogg" type="audio/ogg">
        <source src="/sorteo/assets/media/cassinosong.mp3" type="audio/mpeg">
    </audio>

    <%--BOLITAS PARPADEANTES--%>
    <%--<div style="position:absolute;z-index:1" id="dvMovimiento">
        <img src="/sorteo/assets/images/background01g.png?v=1233" style="width:1920px;height:1080px;" />
    </div>
    <div style="position:absolute;z-index:2;display:none;" id="dvMovimiento1">
        <img src="/sorteo/assets/images/background02g.png?v=1235" style="width:1920px;height:1080px;" />
    </div>--%>

    <div id="lstGanadores" runat="server"></div>

    <div style="width:100px;height:auto;position:absolute;top:450px;left:1600px;z-index:3">
        <a href="javascript:;" id="btnMachine">
            <img src="/sorteo/assets/images/btn01.png" />
        </a>
    </div>

    <script src="/assets/js/jquery.min.js"></script>
    <script src="/assets/js/bootstrap.min.js"></script>
    <script src="/assets/js/jquery.funciones.min.js"></script>
    <script src="assets/plugins/jQuery-SlotMachine/dist/slotmachine.js"></script>
    <script src="assets/plugins/jQuery-SlotMachine/dist/jquery.slotmachine.js"></script>
    <script type="text/javascript">
        $(function () {
            movimiento(1);
        })

        const element = document.querySelector('#lstGanadores');
        const machine = new SlotMachine(element, {
            active: 0,
            auto: false,
            delay:2000
        });
        function onComplete(active) {
            if ($('#ganador' + this.active).data('id') != 0) {
                ajaxSend('/sorteo/ajax/FormInsertarGanadorS1_ajax', { 'conId': $('#ganador' + this.active).data('id'), 'bolConsecutivo': $('#ganador' + this.active).data('bol'), 'camId': $('#ganador' + this.active).data('cam') },
                    null, function () { $('#btnMachine').removeAttr('onclick').attr('onclick', 'location.reload();').html('<img src="/sorteo/assets/images/btn02.png" style="width:310px;height:auto;"/>'); });
            }
            
        }
        btnMachine.addEventListener('click', () => {
            machine.shuffle(2, onComplete);
        });

        function okupdate() {
            alert('¡Felicidades!');
            location.reload();
        }

        function movimiento(accion) {
            if (accion == 1) {
                $('#dvMovimiento').hide('fast');
                $('#dvMovimiento1').show('fast');
                setTimeout(function () { movimiento(2); }, 1000);
            }
            else {
                $('#dvMovimiento1').hide('fast');
                $('#dvMovimiento').show('fast');
                setTimeout(function () { movimiento(1); }, 1000);
            }
        };
    </script>
</body>
</html>
