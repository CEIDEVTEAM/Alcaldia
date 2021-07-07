﻿
var map;
var markers = [];
var heatMapData = [];
//-34.90414838859055, -54.95240618763575
//39.866667°, -4.033333°
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

// Adds a marker to the map and push to the array.
function addMarker(location) {
    const marker = new google.maps.Marker({
        position: location,
        map: map,
    });
    markers.push(marker);
}

// Sets the map on all markers in the array.
function setMapOnAll(map) {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

// Removes the markers from the map, but keeps them in the array.
function clearMarkers() {
    setMapOnAll(null);
}

// Shows any markers currently in the array.
function showMarkers() {
    setMapOnAll(map);
}

// Deletes all markers in the array by removing references to them.
function deleteMarkers() {
    clearMarkers();
    markers = [];
}

//Delete Polygon
function removeLine(name) {

    name.setMap(null);
}




function showArrays(event) {

    const marker = this;

    let contentString =
        "<b>Zona: PEPE</b><br>" +
        "Esta Ubicación: <br>" +
        event.latLng.lat() +
        "," +
        event.latLng.lng() +
        "<br>";

    // Iterate over the vertices.
    /*for (let i = 0; i < vertices.getLength(); i++) {
        const xy = vertices.getAt(i);
        contentString +=
            "<br>" + "Coordenada " + i + ":<br>" + xy.lat() + "," + xy.lng();
    }*/
    // Replace the info window's content and position.
    infoWindow.setContent(contentString);
    infoWindow.setPosition(event.latLng);
    infoWindow.open(map);
}

function createPoly(coordinates) {

    var coords = [];
    for (let i = 0; i < coordinates.length; i++) {

        let latitude = parseFloat(coordinates[i].getPosition().lat().toFixed(6));
        let long = parseFloat(coordinates[i].getPosition().lng().toFixed(6));
        let singleCoord = { lat: latitude, lng: long };
        coords.push(singleCoord);

    }

    var color = document.getElementById("colorPicker").value;
    //var name = document.getElementById("zoneColor").value;

    const polyCoords = coords;
    // Construct the polygon.
    const polygon = new google.maps.Polygon({
        paths: polyCoords,
        strokeColor: color,
        strokeOpacity: 0.8,
        strokeWeight: 3,
        fillColor: color,
        fillOpacity: 0.90,
        editable: true

    });
    polygon.setMap(map);

    deleteMarkers();


    polygon.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

    document.getElementById("btn1").addEventListener("click", function () {
        getZona(polygon)
    });

    return polygon;
}

function getZona(polygon) {
    var poligono = polygon;
    var vertices = poligono.getPath();
    var valTxtNombre = document.getElementById("nombre").value;
    var valTxtColor = document.getElementById("colorPicker").value;
    var colCords = [];


    for (let i = 0; i < vertices.getLength(); i++) {
        const xy = vertices.getAt(i);
        let lat = xy.lat();
        let long = xy.lng();
        let hash = i;

        colCords.push({ latitud: lat, longitud: long, orden: hash })

    }
    var json = { nombre: valTxtNombre, color: valTxtColor, colVertices: colCords }
    $.ajax({
        type: 'POST',
        data: json,
        url: 'AddZona',
        success: function (respuesta) {

        },
        error: function (respuesta) {

        }
    })


}


function handleResponse() {

    $.ajax({
        type: 'GET',

        url: 'PopulateMarkers',
        success: function (response) {
            for (let i = 0; i < response.length; i++) {

                markersPopulate(response[i]);

            }

            GetColorReferences();
        },
        error: function (response) {

        }
    })

}

function markersPopulate(item) {

    let latitude = parseFloat(item.LatitudReclamo);
    let long = parseFloat(item.LongitudReclamo);
    let singleCoord = { lat: latitude, lng: long };
    var fh = item.fechaYhora;
    var res = fh.slice(6, 19);
    var intres = parseInt(res);
    var f = new Date(intres);
    // const formatYmd = date => date.toISOString().slice(0, 10);
    //let f = new Date(date);

    let mes = f.getMonth() + 1;
    if (mes < 10) {
        mes = "0" + mes;
    }
    let dia = f.getDate();
    if (dia < 10) {
        dia = "0" + dia;
    }
    let anio = f.getFullYear();
    let hora = f.getHours();
    let min = f.getMinutes();

    let nuevaFecha = (dia + "/" + mes + "/" + anio + " " + hora + ":" + min);


    const contentString =
        '<div id="content">' +
        '<div id="siteNotice">' +
        "</div>" +
        '<h5 id="firstHeading" class="firstHeading">Numero de Reclamo: ' + item.id + '</h5>' +
        '<div id="bodyContent"></hr>' +
        "<p><b> Retraso:</b> " + item.tiempoDeRetraso + " </p>" +
        "<p><b> Descripción:</b> " + item.observaciones + " </p>" +
        "<p><b> Tipo de reclamo:</b> " + item.nombreTipoReclamo + " </p>" +
        "<p><b> Cuadrilla:</b> " + item.idCuadrilla + " </p>" +
        "<p><b> Fecha:</b> " + nuevaFecha + "</p>" +


        "</div>" +
        "</div>";

    var pinColor = item.color;
    var pinImage = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|" + pinColor,
        new google.maps.Size(21, 34),
        new google.maps.Point(0, 0),
        new google.maps.Point(10, 34));
    var pinShadow = new google.maps.MarkerImage("http://chart.apis.google.com/chart?chst=d_map_pin_shadow",
        new google.maps.Size(40, 37),
        new google.maps.Point(0, 0),
        new google.maps.Point(12, 35));

    const infowindow = new google.maps.InfoWindow({
        content: contentString,
    });
    const marker = new google.maps.Marker({
        position: singleCoord,
        map,
        title: "Reclamo nro: " + item.id,
        icon: pinImage,
        shadow: pinShadow
    });
    marker.addListener("click", () => {
        infowindow.open({
            anchor: marker,
            map,
            shouldFocus: false,

        });
    });
}


function GetColorReferences() {

    $.ajax({
        type: 'GET',

        url: 'ColorReferences',
        success: function (response) {
            document.getElementById("inputGreen").value = "#" + response.GREEN_COLOR_HEX;
            document.getElementById("inputYellow").value = "#" + response.YELLOW_COLOR_HEX;
            document.getElementById("inputRed").value = "#" + response.RED_COLOR_HEX;
            document.getElementById("lbGreen").innerHTML = "Menos de " + response.LIMIT_GREEN_HOURS + " horas."
            document.getElementById("lbYellow").innerHTML = "Entre " + response.LIMIT_GREEN_HOURS + " y " + response.START_RED_HOURS + " horas."
            document.getElementById("lbRed").innerHTML = "Más de " + response.START_RED_HOURS + " horas.";

        },
        error: function (response) {
        }
    });
}




