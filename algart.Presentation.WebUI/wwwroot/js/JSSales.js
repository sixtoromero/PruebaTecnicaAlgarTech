var tbOTableSales;
var listProducts;

$(document).ready(function () {    
    GetCustomers();
    GetProducts();
    ConfigSales();
});


function ConfigSales() {
    
    var tb_configSales = [];

    tbOTableSales = jQuery('#tblSales').dataTable({
        "aaSorting": [[1, "asc"]],
        'aaData': tb_configSales,
        "iDisplayLength": 10,
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

    GetSales();

}

function GetSales() {

    var settings = {
        "url": "http://localhost:9462/api/sales/GetAllAsync",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (data) {

        console.log(data)        

        tbOTableSales.fnClearTable();
        
        for (var x = 0; x < data.Data.length; x++) {            
            param = data.Data[x].Id + '|' + data.Data[x].Date + '|' + data.Data[x].FullName + '|' + data.Data[x].Total + '|' + data.Data[x].Description;
            tbOTableSales.fnAddData([data.Data[x].Id,
                data.Data[x].FullName,
                data.Data[x].Date,
                data.Data[x].Total,
                data.Data[x].Description,
                '<a class="btn btn-default" href="#"  data-toggle="modal" data-target="#modalSale" onclick="GetUpdateSales(' + "'" + param + "'" + ')" role="button"><img src="../images/update.png" /></a><a class="btn btn-default" href="#"  onclick="DeleteSale(' + "'" + data.Data[x].Id + "'" + ')" role="button"><img src="../images/delete.png" /></a>']);
        }
    });
}

function GetProducts() {

    $("#cboProductos").empty();

    var settings = {
        "url": "http://localhost:9462/api/product/GetAllAsync",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (data) {            

        $.ajax(settings).done(function (data) {

            listProducts = data.Data;

            console.log('Productos', data);
            $("#cboProductos").append("<option  value='-1'>SELECCIONE</option>");
            for (var x = 0; x < data.Data.length; x++) {
                $("#cboProductos").append("<option  value=" + data.Data[x].Id + ">" + data.Data[x].Name + "</option>");
            }
        });
    });
}

function GetCustomers() {

    $("#cboClientes").empty();

    var settings = {
        "url": "http://localhost:9462/api/customer/GetAllAsync",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (data) {
        console.log('Customer', data);
        $("#cboClientes").append("<option  value='-1'>SELECCIONE</option>");
        for (var x = 0; x < data.Data.length; x++) {
            $("#cboClientes").append("<option  value=" + data.Data[x].Id + ">" + data.Data[x].Names + " " + data.Data[x].Surnames + "</option>");
        }
    });
}


function GetUpdateSales(response) {
    let resp = response.split('|');
    //$("#modalSale").modal().show();
    $("#modalSale").modal({ backdrop: "static" });
}

function getNewVal(item) {
    //alert(item.value);        
    const prod = listProducts.find(p => p.Id === parseInt(item.value));
    $("#txtValor").val(prod.Price);
    $("#txtColor").val(prod.Color);
    $("#txtTalla").val(prod.Size);
    //$("txtCantidad").val(prod.Size);

    $("#txtCantidad").focus();
}

function calcProduct() {    
    const value = parseInt($("#txtCantidad").val());
    if (value != '') {
        let total = parseFloat($("#txtValor").val()) * value;
        $("#txtTotal").val(total)
    } else {
        $("#txtTotal").val(0);
    }
}


    

