function confirmation(id) {

    swal({
        title: "Cancelar Reclamo",
        text: "¡Una vez cancelado la alcaldía no lo atenderá!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            
            if (willDelete) {
                deleteReclamo(id);
                swal("¡Su reclamo ha sido cancelado!", {
                    icon: "success",
                    button: "Aww yiss!",
                   
                });
                location.reload(); 
                
            } else {
                swal("¡Su reclamo NO ha sido cancelado!");
            }
        });
    
}

function deleteReclamo(id) {
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



