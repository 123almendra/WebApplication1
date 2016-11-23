function iniciar() {
    debugger;
    $("#btnBuscar").on("click", buscar);
};

function buscar() {
    debugger;
    
    var dateInicio = $("#Filtro_dateInicio").val();
    var dateFin =  $("#Filtro_dateFin").val();
    
    var urlBuscarDoc = doc.Urls.searchDocUrl;
    debugger;
    $.ajax({
        url: urlBuscarDoc,
        data: {
            dateInicio: dateInicio,
            dateFin: dateFin
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        debugger;
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        debugger;
        console.log(data);
    });
    return false;
}

