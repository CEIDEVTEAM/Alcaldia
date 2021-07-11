document.getElementById("filtrar").onclick = load;

function load() {

    buscar();
   

}

function buscar() {

    var valorTxt = document.getElementById("selectValue").value;
    var fechaIni = document.getElementById("date1").value;
    var fechaFin = document.getElementById("date2").value;

    if (valorTxt == "") {
        valorTxt = "ASIGNADO";
    }
   
    if (fechaIni == "") {
        fechaIni = "01/01/1970";
        fechaFin = "01/01/2070"
    }
    
    var json = { estado: valorTxt, fechaInicial: fechaIni, fechaFinal: fechaFin+" 23:59:59"};

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


