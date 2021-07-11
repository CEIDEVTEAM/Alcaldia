var map;
var markers = [];
var heatMapData = [];

function initMap() {

    const centro = { lat: 39.866667, lng: -4.033333 };
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: centro,
        mapTypeId: "roadmap",

    });
    handleResponse();
}

function initMapTermico() {

    const centro = { lat: 39.866667, lng: -4.033333 };
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: centro,
        mapTypeId: "roadmap",

    });
    if (heatMapData.length == 0) {
        createMapaTermico();
    }

}

document.getElementById("btnFiltroMapaCalor").addEventListener("click", createMapaTermicoWithRange);

function createMapaTermicoWithRange() {
    heatMapData = [];
    var fechaIn = document.getElementById("fechaInicio").value.toLocaleString();
    var fechaFn = document.getElementById("fechaFinal").value.toLocaleString();

    var json = {
        fechaInicial: fechaIn + " 00:00:00",
        fechaFinal: fechaFn + " 23:59:59"
    }

    $.ajax({
        type: 'POST',
        data: json,
        url: 'PopulateLatLngWithRange',
        success: function (response) {
            for (let i = 0; i < response.length; i++) {
                var cons = { location: new google.maps.LatLng(response[i].latitud, response[i].longitud), weight: 0.3 };

                heatMapData.push(cons);
            }
            if (heatMapData.length > 0) {
                $("#map").empty();
                initMapTermico();
                var heatmap = new google.maps.visualization.HeatmapLayer({
                    data: heatMapData,
                    radius: 35,

                });
                heatmap.setMap(map);
            }
            else {
                alert("no hay datos en el rango");
            }



        },
        error: function (response) {

        }
    })
}

function createMapaTermico() {
    heatMapData = [];

    $.ajax({
        type: 'GET',

        url: 'PopulateLatLng',
        success: function (response) {
            for (let i = 0; i < response.length; i++) {
                var cons = { location: new google.maps.LatLng(response[i].latitud, response[i].longitud), weight: 0.3 };

                heatMapData.push(cons);
            }
            var heatmap = new google.maps.visualization.HeatmapLayer({
                data: heatMapData,
                radius: 35,

            });
            heatmap.setMap(map);

        },
        error: function (response) {

        }
    })


}


