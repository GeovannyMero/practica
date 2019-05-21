function GuardarCliente(key, values) {
    $.post("/Cliente/Guardar").done(function (data) {
        console.log(data);
    }).fail(function (error) {
        alert(error);
        console.log(error);
    }).always(function (result) {
        console.log(result);
    });


}

