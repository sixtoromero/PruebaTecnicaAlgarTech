var tbOTableSales;
var oTableProduct;

var listProducts;
var itemsProducts = [];
var total = 0;

$(document).ready(function () {    
    GetCustomers();
    //GetProducts();    
    GetSaleDepartments();

    ConfigProducts();
    ConfigSales();

    $('[data-toggle="tooltip"]').tooltip();   

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

function ConfigProducts() {
    
    var tb_configProducts = [];

    oTableProduct = jQuery('#items').dataTable({
        "aaSorting": [[1, "asc"]],
        'aaData': tb_configProducts,
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

    const SalesDepartmentId = parseInt($("#cboDepartamento").val());

    var settings = {
        "url": "http://localhost:9462/api/product/GetProductsBySaleDepartmentIdAsync?SalesDepartmentId=" + SalesDepartmentId,
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

function getProduct(item) {
    //alert(item.value);        
    
    const prod = listProducts.find(p => p.Id === parseInt(item.value));

    $("#txtValor").val(prod.Price);
    $("#txtColor").val(prod.Color);
    $("#txtTalla").val(prod.Size);    
    $("#txtInventario").val(prod.Inventory);
    $("#txtCantidad").val('');

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

function agregarItem() {

    const ipro = itemsProducts.find(p => p.Id === parseInt($("#cboProductos").val()));

    if (ipro != undefined) {
        Swal.fire({
            icon: 'warning',
            title: 'Oops...',
            text: 'El producto ya se encuentra ingresado.!',
            footer: '<p>Intenta con otro producto</p>'
        });
        return;
    }

    if ($("#txtCantidad").val() == '' || parseInt($("#cboProductos").val()) == -1) {
        Swal.fire({
            icon: 'warning',
            title: 'Oops...',
            text: 'Algunos campos son obligatorios'
        });
        return;
    }

    const iprod = listProducts.find(p => p.Id === parseInt($("#cboProductos").val()));
    if (parseInt($("#txtCantidad").val()) > iprod.Inventory) {
        Swal.fire({
            icon: 'warning',
            title: 'Oops...',
            text: 'Inventario del producto no disponible'
        });
        return;
    }

    const prod = listProducts.find(p => p.Id === parseInt($("#cboProductos").val()));
    const totalProd = parseFloat(prod.Price) * parseInt($("#txtCantidad").val());    

    let newItem = {
        Id: prod.Id,
        Name: prod.Name,
        Price: prod.Price,
        Amount: parseInt($("#txtCantidad").val()),
        Total: totalProd,
    };

    itemsProducts.push(newItem);

    oTableProduct.fnClearTable();
    for (var x = 0; x < itemsProducts.length; x++) {
        total = total + itemsProducts[x].Total;
        oTableProduct.fnAddData([itemsProducts[x].Name,
            itemsProducts[x].Price,
            itemsProducts[x].Amount,
            itemsProducts[x].Total,
            '<input id="e' + itemsProducts[x].Id + '" type="button" value="quitar" onclick="removeItem(' + "'" + itemsProducts[x].Id + "'" + ')"/>']);
    }

    $("#totalVenta").text(total);

    $("#txtValor").val('');
    $("#txtColor").val('');
    $("#txtTalla").val('');
    $("#txtCantidad").val('');
    $("#cboProductos").val('-1');

}

function generateSale() {

    if (itemsProducts.length == 0) {
        Swal.fire({
            icon: 'warning',
            title: 'Oops...',
            text: 'Debe agregar un item por lo menos, para generar la venta. Intente nuevamente por favor.'
        });
        return;
    }

    if (parseInt($("#cboClientes").val()) == -1) {
        Swal.fire({
            icon: 'warning',
            title: 'Oops...',
            text: 'Algunos campos son obligatorios'
        });
        return;
    }

    let detail = []

    for (var x = 0; x < itemsProducts.length; x++) {
        let items = {
            Id: 0,
            SaleId: 0,
            ProductId: itemsProducts[x].Id,
            Amount: itemsProducts[x].Amount
        };
        detail.push(items);
    }

    let newSale = {
        Id: 0,
        CustomerId: $("#cboClientes").val(),
        Total: total,
        Description: $("#txtDescripcion").val(),
        SaleDetails: detail
    };    

    var settings = {
        "url": "http://localhost:9462/api/sales/InsertAsync",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify(newSale),
    };

    $.ajax(settings).done(function (response) {
        console.log(response);
        if (response.IsSuccess) {

            $("#cboClientes").val(-1);
            $("#txtDescripcion").val('');

            itemsProducts = [];
            oTableProduct.fnClearTable();

            GetProducts();

            Swal.fire({
                icon: 'success',
                title: 'Felicidades',
                text: 'Se ha registrado correctamente la venta.'
            });
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Ha ocurrido un error inesperado: ' + response.Message
            });
        }
    });
}

function GetSaleDepartments() {
    
    $("#cboDepartamento").empty();

    var settings = {
        "url": "http://localhost:9462/api/SalesDepartment/GetAllAsync",
        "method": "GET",
        "timeout": 0,
    };    

    $.ajax(settings).done(function (data) {
        debugger;
        console.log('SaleDepartment', data);
        $("#cboDepartamento").append("<option  value='-1'>SELECCIONE</option>");
        for (var x = 0; x < data.Data.length; x++) {
            $("#cboDepartamento").append("<option  value=" + data.Data[x].Id + ">" + data.Data[x].Department + "</option>");
        }
    });
}
