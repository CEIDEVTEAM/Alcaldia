document.getElementById("filtrar").onclick = load;

function load() {

    buscar();
   

}

function buscar() {

    var valorTxt = document.getElementById("selectValue").value;
    var fechaIni = document.getElementById("date1").value;
    var fechaFin = document.getElementById("date2").value;
    
    var json = { estado: valorTxt, fechaInicial: fechaIni + " 00:00:00", fechaFinal: fechaFin+" 23:59:59" };

    $.ajax({
        url: 'GetReclamosPorFechaYestado',
        type: 'POST',
        data: json,
        success: function (result) {

            var test = result;
            $("#divTblRec").html(result);
        }

    });

}


