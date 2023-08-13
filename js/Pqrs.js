var loadFormPQRS = function () {
    var params = {
        'accion': 0,
        'data': $('#cphContenido_data').val()
    };
    ajaxSend('/PQRS/FrmPqrs_ajax', params, 'cphContenido_dvFrmPqrs', function () { })
}


var ingresarPqrs = function () {   
    var params = {
        'accion': 0,
        'data': $('#cphContenido_data').val()
    };
    abrirDialogo('/PQRS/AccederPqrs_ajax', params, '', 'modal-md');
}

var changeValor = function () {
    $('#cphContenido_hdnControl').val('1');
}

var cargarFormularioContacto = function (conNdoc) {
    
    var params = {
        'accion': 0,      
        'conNdoc': conNdoc,
        'data': $('#cphContenido_data').val()
    };
    ajaxSend(
        '/PQRS/FormBuscarContacto_ajax'
        , params
        , 'dvFrmDinamic'
        , function () {            
            //$('#dvRtaRegistro').hide('fast', function () { $('#dvFormContacto').show(); }).html('');
            //if (conNdoc != '') {
            //    buscarContacto(conNdoc, 'crmcontacto');                
            //}
        }
    )
}

var buscarContacto = function (ndoc, accion) {
    
    if (ndoc != '') {
        var params = {
            'accion': accion,
            'ndoc': ndoc,
            'data': $('#cphContenido_data').val()
        };
        ajaxSend(
            '/PQRS/FormBuscarContacto_ajax'
            , params
            , 'dvFrmDinamic'
            , function () { }
        )
    }
}

//var buscarContacto = function (ndoc, accion) {
//    if (ndoc != '') {
//        var params = {
//            'accion': accion,
//            'ndoc': ndoc            
//        };
//        ajaxSend(
//            '/PQRS/FormBuscarContacto_ajax'
//            , params
//            , null
//            , function (rs) {
//                rs = eval('(' + rs + ')');                
//                if (rs.data != 'none') {
//                    llenarDatos(rs, accion);
//                } else {
//                    $('.frmDisable').removeAttr('disabled');
//                    mensajeAlerta("No se encuentra registrado")
//                }
//            }
//        )
//    }
//}




var ciudadSelBarrio = 0;
var onchangeSelCiudad = function (dptoId, ciuId, opcBar) {
    ciuId = ciuId || '';
    opcBar = opcBar || '';
    var params = {
        'accion': 'lstCiudad',
        'idTag': $('#hdnIdTag').val(),
        'dptoId': dptoId,
        'ciuId': ciuId,
        'opcBar': opcBar,
        'data': $('#cphContenido_data').val()
    };
    ajaxSend(
        '/PQRS/FormPreCampoPqrs_ajax'
        , params
        , 'dvRandomCiudad'
        , function () {
        }
    )
}
var onchangeSelPaisDpto = function (paisId, dptoId, opcLoc) {
    dptoId = dptoId || '';
    opcLoc = opcLoc || '';
    var params = {
        'accion': 'lstPDpto',
        'idTag': $('#hdnIdTagPDpto').val(),
        'paisId': paisId,
        'dptoId': dptoId,
        'opcLoc': opcLoc,
        'data': $('#cphContenido_data').val()
    };
    ajaxSend(
        '/PQRS/FormPreCampoPqrs_ajax'
        , params
        , 'dvRandomDpto'
        , function () {
        }
    )
}
var onchangeSelPais = function (paisId, ciuId, opcLoc) {
    ciuId = ciuId || '';
    opcLoc = opcLoc || '';
    var params = {
        'accion': 'lstPCiudad',
        'idTag': $('#hdnIdTagPC').val(),
        'paisId': paisId,
        'ciuId': ciuId,
        'opcLoc': opcLoc,
        'data': $('#cphContenido_data').val()
    };
    ajaxSend(
        '/PQRS/FormPreCampoPqrs_ajax'
        , params
        , 'dvRandomPCiudad'
        , function () {
        }
    )
}
var onchangeSelLocBarrio = function (locId, barId) {
    ciudadSelBarrio = locId;
    barId = barId || '';
    var params = {
        'accion': 'lstLocBarrio',
        'idTag': $('#hdnIdTagBar').val(),
        'locId': locId,
        'barId': barId,
        'data': $('#cphContenido_data').val()
    };
    if ($('#dvRandomBarrio').length) {
        ajaxSend(
            '/PQRS/FormPreCampoPqrs_ajax'
            , params
            , 'dvRandomBarrio'
            , function () {

            }
        )
    }
}
//var ciudadSelLocalidad = 0;
//var onchangeSelLocalidad = function (ciuId, locId) {
//    ciudadSelLocalidad = ciuId;
//    locId = locId || '';
//    var params = {
//        'accion': 'lstLocalidad',
//        'idTag': $('#hdnIdTagLoc').val(),
//        'ciuId': ciuId,
//        'locId': locId
//    };
//    ajaxSend(
//        '/PQRS/FormPreCampoPqrs_ajax'
//        , params
//        , 'dvRandomLocalidad'
//        , function () {

//        }
//    )
//}
var addBarrio = function () {
    if (ciudadSelBarrio == 0) {
        mensajeAlerta("Debe seleccionar una ciudad");
    } else {
        var params = {
            'accion': 'addBarrio',
            'ciuId': ciudadSelBarrio,
            'data': $('#cphContenido_data').val()
        }
        abrirDialogo('/PQRS/FormPreCampoPqrs_ajax', params, function () { }, 'modal-sm');
    }
}
//var onchangeSelBarrio = function (ciuId, barId) {
//    ciudadSelBarrio = ciuId;
//    barId = barId || '';
//    var params = {
//        'accion': 'lstBarrio',
//        'idTag': $('#hdnIdTagCiu').val(),
//        'ciuId': ciuId,
//        'barId': barId
//    };
//    ajaxSend(
//        '/PQRS/FormPreCampoPqrs_ajax'
//        , params
//        , 'dvRandomBarrio'
//        , function () {

//        }
//    )
//}

