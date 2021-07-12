window.onload = initMap;

var map;
var marker;
var dto = [];

//iniciarMapa
function initMap() {

    var currentPoly = [];
    const centro = { lat: 39.866667, lng: -4.033333 };
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: centro,
        mapTypeId: "roadmap",
    });
   
    document.getElementById("smBut").addEventListener("click", addReclamo);
    
    handleResponse();
}

//funciones auxiliares
function setMapOnAll(map) {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

function clearMarkers() {
    setMapOnAll(null);
}

function showMarkers() {
    setMapOnAll(map);
}

function deleteMarkers() {
    clearMarkers();
    markers = [];
}

function removeLine(name) {

    name.setMap(null);
}

function showArrays(event) {

    if (marker != undefined) {
        marker.setMap(null);
    }
    const polygon = this;
    const vertices = polygon.getPath();
    const nombre = polygon.name;
    const id = polygon.id;
    let contentString =
        "<b>Zona: " + nombre + "</b><br>" +
        "Esta Ubicación: <br>" +
        event.latLng.lat() +
        "," +
        event.latLng.lng() +
        "<br>";


    marker = new google.maps.Marker({
        position: event.latLng,
        map,
        animation: google.maps.Animation.DROP,
        title: "Ubicación",
    });

    const consult = google.maps.geometry.poly.containsLocation(
        event.latLng,
        polygon
    )
        ? true
        : false;

    if (consult) {

        idZona = id;
        lat = event.latLng.lat();
        long = event.latLng.lng();

        dto = { id: idZona, latitud: lat, longitud: long };

    }

}


//nuevo reclamo
function addReclamo() {
    var obs = document.getElementById("observaciones").value;
    var tpReclamo = document.getElementById("tipoReclamo").value;

    if (dto.id != undefined) {

        var jSon = { observaciones: obs, nombreTipoReclamo: tpReclamo, latitudReclamo: dto.latitud, longitudReclamo: dto.longitud, idZona: dto.id }

        $.ajax({
            type: 'POST',
            data: jSon,
            url: 'AddReclamo',
            success: function (respuesta) {

            },
            error: function (respuesta) {

            }
        })
    } else {

        alert("Debe ingresar la ubicación del reclamo.");

    }
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


//imprimir zonas
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

        url: 'PopulatePolygons',
        success: function (response) {
            for (let i = 0; i < response.length; i++) {

                zonesPopulate(response[i]);
                console.log(response[i]);
            }

        },
        error: function (response) {

        }
    })

}

function zonesPopulate(item) {

    var coords = [];
    var orderVerts = item.colVertices.sort((a, b) => {
        return a.orden - b.orden;
    });

    for (let i = 0; i < orderVerts.length; i++) {

        let latitude = parseFloat(item.colVertices[i].latitud);
        let long = parseFloat(item.colVertices[i].longitud);
        let singleCoord = { lat: latitude, lng: long };
        coords.push(singleCoord);

    }

    var color = item.color;
    var nombre = item.nombre;
    var id = item.id;

    const polyCoords = coords;
    // Construct the polygon.
    const polygon = new google.maps.Polygon({
        id: id,
        name: nombre,
        paths: polyCoords,
        strokeColor: color,
        strokeOpacity: 0.2,
        strokeWeight: 3,
        fillColor: color,
        fillOpacity: 0.2,


    });
    polygon.setMap(map);


    polygon.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

}
function createPoint(map) {

    // creates a draggable marker to the given coords
    var vMarker = new google.maps.Marker({
        position: new google.maps.LatLng(39.866667, -4.033333),
        draggable: true
    });
    google.maps.event.addListener(vMarker, 'dragend', function (evt) {
        map.panTo(evt.latLng);
    });

    map.setCenter(vMarker.position);

    // adds the marker on the map
    vMarker.setMap(map);
    var latitude = vMarker.getPosition().lat().toFixed(6);
    var long = vMarker.getPosition().lng().toFixed(6);
    var marcador = { latitud: latitude, longitud: long };

    return marcador;
}

