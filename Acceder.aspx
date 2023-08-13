<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acceder.aspx.cs" Inherits="_Acceder" %>

<!DOCTYPE html>

<html lang="es" xml:lang="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Acceder</title>

    <link rel="stylesheet" href="<%=Page.ResolveUrl("~") %>assets/css/bootstrap.min.css" />
    <link href="assets/css/styles.css" rel="stylesheet" />
</head>
<body>
    <div id="nav-placeholder"></div>

    <div class="bg2">

        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-3 hidden-xs"></div>
                <div class="col-md-4 col-sm-6">
                    <%--<div class="row">
                        <div class="col-md-12 col-xs-12 text-center">
                            <a href="javascript:;"><img src="assets/images/LOGO.png" class="logo" style="height:200px;" /></a>
                        </div>
                    </div>--%>
                    <div id="frmLogin" class="login-form" runat="server">
                        <h3 class="form-title" style="color:#ffffff;">Iniciar Sesión</h3>
                        <div id="dvMsgValidation" class="display-hide"></div>
                        <input type="hidden" id="url" name="url" value="" runat="server" />
                        <div class="form-group">
                            <label class="control-label visible-ie8 visible-ie9">Documento</label>
                            <input class="form-control form-control-solid placeholder-no-fix" type="text" autocomplete="off" placeholder="##########" id="txtNdoc" name="txtNdoc" runat="server" />
                        </div>
                        <div id="panelpwd" class="form-group">
                            <label class="control-label visible-ie8 visible-ie9">Contraseña</label>
                            <input class="form-control form-control-solid placeholder-no-fix" type="password" autocomplete="off" placeholder="***********" id="txtPwd" name="txtPwd" runat="server" />
                        </div>
                        <hr/>
                        <h4 class="form-title" style="color:#ffffff;">*Documento es el mismo con el que se registró</h4>
                        <h4 class="form-title" style="color:#ffffff;">*Contraseña son los últimos 4 dígitos del documento</h4>
                        <hr/>
                        <div class="col-md-12 col-xs-12 form-actions">
                            
                            <label class="col-md-6 col-xs-6 rememberme check" style="color:#ffffff;">
                                <input id="chkRemenber" type="checkbox" name="chkRemenber" > Recordarme
                            </label>

                            <a href="javascript:;" onclick="login();" class="col-md-6 col-xs-6 btn btn-success uppercase" id="loginpwd">Acceder</a>
                            
                        </div>
                        
                        <%--<div class="col-md-12 col-xs-12 form-actions text-center" style="margin-top:20px;">
                            <p>¿No estás registrado aún?</p>
                            <a href="./Registro" class="btn btn-success uppercase">Registrarse</a>
                        </div>--%>
                    </div>
                </div>
                <div class="col-md-4 col-sm-3 hidden-xs"></div>
            </div>
        </div>
                        <%--<div class="form-group">  
                    <p>Por favor digita tu número de documento sin puntos(.) ni comas(,)</p>
                    <div class="form-group">
                        <div class="input-group">
                            <div class="input-group-addon"><i class="fa fa-id-card"></i></div>
                            <input class="form-control form-control-solid placeholder-no-fix" type="text" autocomplete="off"  placeholder="Doc de Identificación" id="txtusuario" validar="empty|Debe ingresar el numero de identificacion" name="txtusuario" runat="server"/>                            
                        </div>
                    </div>
                   
                        <div class="form-group">
                            <div class="input-group">                                
                                <button type="button" style="background-color:#525151;color:#fff;" class="btn btn-primary" onclick="formSubmit('dvFrmIgresar','/PQRS/AccederPqrs_ajax','','dvRtaValidacion');"><i class="fa fa-search float-left"></i> Consultar</button>                                
                            </div>
                        </div>
                       
                  
                </div>
        <div id="dvRtaValidacion" class="text-center" style="color:#ff0000"></div>--%>
        <br />
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
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap-datepicker/js/locales/bootstrap-datepicker.es.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap-datetimepicker/js/locales/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/jquery-mask/dist/jquery.mask.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap-select2-406/dist/js/select2.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/bootstrap-select2-406/dist/js/i18n/es.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>assets/global/plugins/jquery-nestable/jquery.nestable.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/jquery.maskMoney.min.js"></script>
    <script type="text/javascript" src="<%= Page.ResolveUrl("~")%>js/Pqrs.js?v=1231454"></script>

    <script>
        $(function () {
            $("#nav-placeholder").load("nav.html");
        });
    </script>
    <script type="text/javascript">
        //$(function () {

        //    loadFormPQRS();

        //    $('#txtNdoc').blur(function () {
        //        //buscarContacto($('#cphContenido_txtNdoc').val(), 'crmcontacto');                
        //    }).numeric();
        //    $('.frmDisable').attr('disabled', 'disabled');
        //    $('#txtNdoc').blur(function () {
        //        if ($(this).val() == '') {
        //            $(this).val('0');
        //        }
        //    }).focusin(function () {
        //        if ($(this).val() == '0') {
        //            $(this).val('');
        //        }
        //    });
        //})

        $(function () {
            $('#txtPwd').on('keypress', function (e) {
                if (e.which == 13) {
                    login();
                }
            });
            //$('#dvMsgValidation').hide();
        })
        var login = function () {
            var ndoc = $('#txtNdoc').val();
            var pwd = $('#txtPwd').val();
            var url = $('#url').val();
            var recordar = ($("#chkRemenber").is(':checked') ? '1' : '0');
            var msgRta = '';
            if (ndoc == '') {
                msgRta = 'Debe ingresar un número de documento';
            }
            if (pwd == '') {
                msgRta += (msgRta != '' ? '<br />' : '') + 'Debe ingresar una contraseña.';
            }
            //if (pin == '') {
            //    msgRta += (msgRta != '' ? '<br />' : '') + 'Debe ingresar un pin.';
            //}
            if (msgRta != '') {
                msgRta = '<button class="close" data-close="alert"></button><span>' + msgRta + '</span>';
                $('#dvMsgValidation').html(msgRta).removeAttr('class').attr('class', 'alert alert-danger');
            }
            if (ndoc=='admin' && pwd=='admin') {
                window.location.href = "/MundialAdmin";
                //document.getElementById('loginpwd').setAttribute('href', baseUrl + '/MundialAdmin/');
            }
            else {
                ajaxSend(
                    '/ajax/Acceder_ajax'
                    , { 'ndoc': ndoc, 'pwd': pwd, 'recordar': recordar, 'url':url }
                    , null
                    , function (data) {
                        data = eval('(' + data + ')');

                        if (data.rta == '') {
                            window.location.href = data.url;
                        }
                        else {
                            msgRta = '<button class="close" data-close="alert"></button><span>' + data.rta + '</span>';
                            $('#dvMsgValidation').html(msgRta).removeAttr('class').attr('class', 'alert alert-danger');
                        }
                    }
                )
            }
        }
    </script>
</body>
</html>
