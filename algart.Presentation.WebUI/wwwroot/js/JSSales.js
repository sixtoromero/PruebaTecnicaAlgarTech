var tbOTableSales;
var oTableProduct;

var listProducts;
var itemsProducts = [];
var listSale = [];

var total = 0;

$(document).ready(function () {    
    GetCustomers();
    //GetProducts();    
    GetSaleDepartments();

    ConfigProducts();
    ConfigSales();
    GetPlanSepare();

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

        console.log(data);    
        listSale = data.Data;

        tbOTableSales.fnClearTable();
        
        for (var x = 0; x < data.Data.length; x++) {            
            param = data.Data[x].Id; // + '|' + data.Data[x].CustomerId + '|' + data.Data[x].FullName + '|' + data.Data[x].Total + '|' + data.Data[x].Description;
            tbOTableSales.fnAddData([data.Data[x].Id,
                data.Data[x].FullName,
                data.Data[x].Date,
                data.Data[x].Total,
                data.Data[x].Description,
                '<a class="btn btn-default" href="#" onclick="GetUpdateSales(' + "'" + param + "'" + ')" role="button"><img src="../images/update.png" /></a><a class="btn btn-default" href="#"  onclick="DeleteSale(' + "'" + data.Data[x].Id + "'" + ')" role="button"><img src="../images/delete.png" /></a>']);
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

    
    const isale = listSale.find(p => p.Id === parseInt(response));
    
    $("#cboClientes").val(isale.CustomerId);
    $("#txtDescripcion").val(isale.Description);
    $("#cboPlanSepare").val(isale.PlanSeparateId);
    $("#totalVenta").text(isale.Total);

    itemsProducts = isale.SaleDetails;
    
    oTableProduct.fnClearTable();
    for (var x = 0; x < itemsProducts.length; x++) {
        total = total + itemsProducts[x].Total;
        oTableProduct.fnAddData([itemsProducts[x].Name,
        itemsProducts[x].Price,
        itemsProducts[x].Amount,
            itemsProducts[x].Total,
            '<input id="e' + itemsProducts[x].Id + '" type="button" value="quitar" onclick="removeItem(' + "'" + itemsProducts[x].ProductId + "'" + ')"/>']);
    }


    $("#txtSaleId").val(isale.Id);

    $('.nav-tabs a[href="#crear"]').tab('show');

    //$("#modalSale").modal().show();
    //$("#modalSale").modal({ backdrop: "static" });

    //Llenar itemsProducts de la venta seleccionada
    //Consultar el cliente de listCustomer

}

function getProduct(item) {
    //alert(item.value);        
    
    const prod = listProducts.find(p => p.Id === parseInt(item.value));

    $("#txtValor").val(prod.Price);
    $("#txtColor").val(prod.Color);
    $("#txtTalla").val(prod.Size);    
    $("#txtInventario").val(prod.Inventory);
    $("#txtTotal").val(''); 
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
    
    const ipro = itemsProducts.find(p => p.ProductId === parseInt($("#cboProductos").val()));

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
        Id: 0,
        ProductId: prod.Id,
        Name: prod.Name,
        Price: prod.Price,
        Amount: parseInt($("#txtCantidad").val()),
        Total: totalProd,
    };

    itemsProducts.push(newItem);

    oTableProduct.fnClearTable();
    total = 0;
    for (var x = 0; x < itemsProducts.length; x++) {
        total = total + itemsProducts[x].Total;
        oTableProduct.fnAddData([itemsProducts[x].Name,
            itemsProducts[x].Price,
            itemsProducts[x].Amount,
            itemsProducts[x].Total,
            '<input id="e' + itemsProducts[x].ProductId + '" type="button" value="quitar" onclick="removeItem(' + "'" + itemsProducts[x].ProductId + "'" + ')"/>']);
    }

    $("#totalVenta").text(total);

    $("#txtValor").val('');
    $("#txtColor").val('');
    $("#txtTalla").val('');
    $("#txtCantidad").val('');
    $("#txtInventario").val('');
    $("#txtTotal").val('');

    $("#cboProductos").val('-1');

    console.log('Items Agregados', itemsProducts);
}

function generate() {

    Swal.fire({
        title: 'Está seguro de generar la venta?',
        text: "Recuerde que al generar la venta afecta el inventario de los productos!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Generar Venta!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            generateSale();
        }
    });
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
            ProductId: itemsProducts[x].ProductId,
            Amount: itemsProducts[x].Amount            
        };
        detail.push(items);
    }
    
    let isPlanSepare = false;
    if (parseInt($("#cboPlanSepare").val()) > 0) {
        isPlanSepare = total >= parseFloat($("#txtSepare").val()) ? true : false;
    }
        

    let newSale = {
        Id: parseInt($("#txtSaleId").val()),
        CustomerId: $("#cboClientes").val(),
        Total: total,
        Description: $("#txtDescripcion").val(),
        IsSeparatePlan: isPlanSepare,
        PlanSeparateId: $("#cboPlanSepare").val(),
        SaleDetails: detail
    };    
    var settings;

    if ($("#txtSaleId").val() == "0") {
        settings = {
            "url": "http://localhost:9462/api/sales/InsertAsync",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/json"
            },
            "data": JSON.stringify(newSale),
        };
    }else {
        settings = {
            "url": "http://localhost:9462/api/sales/UpdateAsync",
            "method": "PUT",
            "timeout": 0,
        };

        var settings = {
            "url": "http://localhost:9462/api/sales/UpdateAsync",
            "method": "PUT",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/json"
            },
            "data": JSON.stringify(newSale),
        };
    }

    $.ajax(settings).done(function (response) {
        
        console.log(response);

        if (response.IsSuccess) {

            $("#cboClientes").val(-1);
            $("#txtDescripcion").val('');

            itemsProducts = [];
            oTableProduct.fnClearTable();

            GetProducts();
            GetSales();
            //ConfigSales();

            Swal.fire({
                icon: 'success',
                title: 'Felicidades',
                text: 'Se ha registrado correctamente la venta.'
            });

            cleanScreen();

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
        
        console.log('SaleDepartment', data);
        $("#cboDepartamento").append("<option  value='-1'>SELECCIONE</option>");
        for (var x = 0; x < data.Data.length; x++) {
            $("#cboDepartamento").append("<option  value=" + data.Data[x].Id + ">" + data.Data[x].Department + "</option>");
        }
    });
}

function DeleteSale(Id) {
    Swal.fire({
        title: 'Está seguro de eliminar la venta seleccionada??',
        text: "No podrás revertir esto.!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminar!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            //Aquí el código para eliminar
            var settings = {
                "url": "http://localhost:9462/api/sales/DeleteAsync?Id=" + parseInt(Id),
                "method": "DELETE",
                "timeout": 0,
            };

            $.ajax(settings).done(function (response) {
                GetSales();

                Swal.fire({
                    icon: 'success',
                    title: 'Registro Eliminado',
                    text: 'Se ha registrado correctamente la venta.'
                });
            });
        }
    });
}

function cleanScreen() {
    itemsProducts = [];
    listSale = [];
    
    oTableProduct.fnClearTable();
    
    $("#cboProductos").empty();

    $("#txtValor").val('');
    $("#txtColor").val('');
    $("#txtTalla").val('');
    $("#txtCantidad").val('');
    $("#txtInventario").val('');
    $("#txtTotal").val('');
    $("#txtDescripcion").val('');
    $("#totalVenta").text('0');
    $("#cboClientes").val(-1);
    $("#cboDepartamento").val(-1);
    $("#cboPlanSepare").val(0);
}

function removeItem(productId) {
    Swal.fire({
        title: 'Está seguro de eliminar el producto agregado?',
        text: "podrás volverlo a incluir.!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminar!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            //Aquí el código para eliminar            
            for (let i = 0; i < itemsProducts.length; i++) {
                if (itemsProducts[i].ProductId === parseInt(productId)) {
                    itemsProducts.splice(i, 1);
                    break;
                }
            }

            oTableProduct.fnClearTable();
            total = 0;
            for (var x = 0; x < itemsProducts.length; x++) {
                total = total + itemsProducts[x].Total;
                oTableProduct.fnAddData([itemsProducts[x].Name,
                itemsProducts[x].Price,
                itemsProducts[x].Amount,
                itemsProducts[x].Total,
                '<input id="e' + itemsProducts[x].ProductId + '" type="button" value="quitar" onclick="removeItem(' + "'" + itemsProducts[x].ProductId + "'" + ')"/>']);
            }

            $("#totalVenta").text(total);
        }
    });
}

function GetPlanSepare() {

    $("#cboPlanSepare").empty();

    var settings = {
        "url": "http://localhost:9462/api/PlanSeparate/GetAllAsync",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (data) {
        $("#cboPlanSepare").append("<option  value='0'>SELECCIONE</option>");
        for (var x = 0; x < data.Data.length; x++) {
            $("#cboPlanSepare").append("<option  value=" + data.Data[x].Id + ">" + data.Data[x].Description + "</option>");
        }
    });
}

