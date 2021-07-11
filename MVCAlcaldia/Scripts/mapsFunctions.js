window.onload = initMap;

var map;
var markers = [];


//funcion iniciadora del mapa
function initMap() {

    var currentPoly = [];
    const centro = { lat: 39.866667, lng: -4.033333 };
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 14,
        center: centro,
        mapTypeId: "roadmap",
    });
    // This event listener will call addMarker() when the map is clicked.
    map.addListener("click", (event) => {
        addMarker(event.latLng);
    });
    
    document.getElementById("btn2").addEventListener("click", function () {
        createPoly(markers)
    });

    
    handleResponse();
}

//pequeñas funcionalidades auxiliares
function addMarker(location) {
    const marker = new google.maps.Marker({
        position: location,
        map: map,
    });
    markers.push(marker);
}

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
    
    const polygon = this;
    const vertices = polygon.getPath();
    const nombre = polygon.name;
    const recAct = polygon.count;
    let contentString =
        "<b>Zona: " + nombre + "</b><br>" +
        "<b>Reclamos activos actuales: " + recAct + "</b><br>" 
        
    infoWindow.setContent(contentString);
    infoWindow.setPosition(event.latLng);
    infoWindow.open(map);
}

//guardar zona
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

        colCords.push({ latitud: lat, longitud: long, orden:hash })
        
    }
    var json = { nombre: valTxtNombre, color: valTxtColor, colVertices: colCords  }
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
//graficar zonas
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
    var rActivos = item.reclamosActivos;

    const polyCoords = coords;
    // Construct the polygon.
    const polygon = new google.maps.Polygon({

        name: nombre,
        count: rActivos,
        paths: polyCoords,
        strokeColor: color,
        strokeOpacity: 0.5,
        strokeWeight: 3,
        fillColor: color,
        fillOpacity: 0.2,
        

    });
    polygon.setMap(map);


    polygon.addListener("click", showArrays);
    infoWindow = new google.maps.InfoWindow();

}


