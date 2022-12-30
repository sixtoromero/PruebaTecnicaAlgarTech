var oTable;

function configCategorias() {
    $(document).ready(function () {
        configTable();
        getCategorias();
    });
}

function configTable() {    
    var dtCategorias = [];
    $('#tblCategorias tbody').on('click', function (e) {
        e.preventDefault();
        $(Tr_oTableCategorias.fnSettings().aoData).each(function () {
            $(this.nTr).removeClass('row_selected');
        });
        $(event.target.parentNode).addClass('row_selected');
        var aPos = Tr_oTableCategorias.fnGetPosition(event.target.parentNode);
        if (aPos != null) {
            var dtCategorias = Tr_oTableCategorias.fnGetData(aPos);
            // UsuarioSenalado(aData[0], aData[1]);
        }
    });

    oTable = jQuery('#tblCategorias').dataTable({
        "aaSorting": [[1, "asc"]],
        'aaData': dtCategorias,
        "iDisplayLength": 50,
        "oLanguage": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sInfo": "Mostrando desde _START_ hasta _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando desde 0 hasta 0 de 0 registros",
            "sInfoFiltered": "(filtrado de _MAX_ registros en total)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "oPaginate": {
                "sPrevious": "",
                "sNext": ""
            }
        }
    });

    $('#tblCategorias_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Buscar");
    $('#tblCategorias_wrapper .dataTables_length select').addClass("m-wrap small");
    $('#tblCategorias_wrapper .dataTables_length select').select2();    
}

function getCategorias() {
    $.ajax({
        type: "GET",
        cache: false,
        url: "http://localhost:9462/api/Categorias/GetAllAsync",
        data: "",
        success: function (result) {
            if (result.IsSuccess === true) {
                Tr_onListarCategorias(result.Data)
            } else {
                sweetAlert("Oops...", "Ha ocurrido un error al consultar la api!", "warning");
            }
            
        },
        error: function (result) {
            //HideModal($('#modalCategorias'));
            sweetAlert("Oops...", "Ha ocurrido un error al consultar la api!", "warning");
            return;
        }
    });
}

function Tr_onListarCategorias(result) {
    //result[x].Id + "|" + result[x].Descripcion + "|" + result[x].Fecha
    if (result != "") {
        oTable.fnClearTable();
        for (var x = 0; x < result.length; x++) {

            param = result[x].Id + '|' + result[x].Descripcion + '|' + result[x].Fecha

            oTable.fnAddData([
                result[x].Id,
                result[x].Descripcion,
                result[x].Fecha,
                '<center><img src="../images/update.png"  style="cursor: pointer;" onclick="showCategoriaModal(' + "'" + param + "'" + ')"/><img src="../images/delete.png"  style="cursor: pointer;" onclick="deleteCategoria(' + "'" + result[x].Id + "'" + ')"/></center>'
            ]);
        }
    }
    //HideModal($('#modalCategorias'));
}

function showCategoriaModal(result) {        
    var res = result.split('|');
    console.log(result);
    $('#txtId').val(res[0]);
    $('#txtDescripcion').val(res[1]);

    var info = prompt('Registre el nuevo valor por favor.', res[1]);
    
    if (info != null) {
        modificar(info);
    } else {
        $('#txtId').val('');
        $('#txtDescripcion').val('');
    }
    

}

function crear() {
    
    var desc = $("#txtDescripcion").val();
    
    $.ajax({
        url: "http://localhost:9462/api/Categorias/InsertAsync",
        type: "Post",
        data: JSON.stringify({
            descripcion: desc            
        }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            getCategorias();
            sweetAlert("Oops...", 'Registro aregado exitosamente !!!', "success");
        },
        failure: function (data) {            
            sweetAlert("Oops...", data.responseText, "warning");
        },
        error: function (data) {
            sweetAlert("Oops...", data.responseText, "warning");
        }
    });      
}

function modificar(valor) {    

    //var desc = $("#txtDescripcion").val();
    var idCategoria = $("#txtId").val();
    
    $.ajax({
        url: "http://localhost:9462/api/Categorias/UpdateAsync",
        type: "Put",
        data: JSON.stringify({
            id: idCategoria,
            descripcion: valor
        }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            console.log(data);
            if (data.IsSuccess == true) {
                $("#txtDescripcion").val('');
                $("#txtId").val('');

                //sweetAlert("Bien...", 'Registro modificado exitosamente !!!', "success");
                getCategorias();
            } else {
                sweetAlert("Oops...", 'Ha ocurrido un error', "warning");
            }           
        },
        failure: function (data) {            
            //sweetAlert("Oops...", data.responseText, "warning");
            getCategorias();
        },
        error: function (data) {
            //console.log(data);
            getCategorias();
            //sweetAlert("Oops...", data.responseText, "warning");
        }
    });
}

function deleteCategoria(id) {

    //var desc = $("#txtDescripcion").val();    

    $.ajax({
        url: "http://localhost:9462/api/Categorias/DeleteAsync?Id=" + id,
        type: "Delete",        
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            console.log(data);
            if (data.IsSuccess == true) {                
                getCategorias();
            } else {
                sweetAlert("Oops...", 'Ha ocurrido un error', "warning");
            }
        },
        failure: function (data) {
            //sweetAlert("Oops...", data.responseText, "warning");
            getCategorias();
        },
        error: function (data) {
            //console.log(data);
            getCategorias();
            //sweetAlert("Oops...", data.responseText, "warning");
        }
    });
}
