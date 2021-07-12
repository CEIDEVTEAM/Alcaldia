document.getElementById("idZona").addEventListener("click",  confirmation);
function confirmation() {

    swal({
        title: "Cancelar Reclamo",
        text: "¡Una vez cancelado la alcaldía no lo atenderá!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            
            if (willDelete) {
                deleteReclamo();
                swal("¡Su reclamo ha sido cancelado!", {
                    icon: "success",
                    button: "ok!",
                   
                });
                //location.reload(); 
                //grid.refresh(); // refresh the Grid.
            } else {
                swal("¡Su reclamo NO ha sido cancelado!");
            }
        });
    
}

function deleteReclamo() {
    var id = document.getElementById("idZona").value;
    var jSon = { id: id };

    $.ajax({
        url: "Delete",
        data: jSon,
        type: "POST",
        success: function (respuesta) {
           
        },
        error: function (respuesta) {
            
        }
    })
}



/*function confirmation() {
    swal({
        title: "Cancelar Reclamo",
        text: "¡Una vez cancelado la alcaldía no lo atenderá!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {

    var id = document.getElementById("idZona").value;
    var jSon = { id: id };
            if (willDelete) {
                $.ajax({
                    url: "Delete",
                    data: jSon,
                    type: "POST",
                    success: function (respuesta) {
                        swal("¡Su reclamo ha sido cancelado!", {
                            icon: "success",
                            button: "Aww yiss!",

                        });

                    },
                    error: function (respuesta) {
                        swal("¡Su reclamo NO ha sido cancelado!");
                    }
                })

                //location.reload(); 

            } else {

                swal("¡Su reclamo NO ha sido cancelado!");
            }
        });

}*/