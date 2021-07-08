document.getElementById("filtrar").onclick = load;

function load() {

    buscar();
   

}

function buscar() {

    var valorTxt = document.getElementById("selectValue").value;
    var fechaIni = document.getElementById("date1").value;
    var fechaFin = document.getElementById("date2").value;


    var json = { estado: valorTxt, fechaInicial: fechaIni, fechaFinal: fechaFin };

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


