using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public dtoReclamo MaptoDto(Reclamo entity)
    {

        return new dtoReclamo
        {

            id = entity.id,
            estado = entity.estado,
            fechaYhora = entity.fechaYhora,
            observaciones = entity.observaciones,
            idCiudadano = entity.idCiudadano,
            idTipoReclamo = entity.idTipoReclamo,
            idUbicacion = entity.idUbicacion,
            idCuadrilla = entity.idCuadrilla
        };
    }

    public Reclamo MaptoEntity(dtoReclamo dto)
    {

        return new Reclamo
        {

            id = dto.id,
            estado = dto.estado,
            fechaYhora = dto.fechaYhora,
            observaciones = dto.observaciones,
            idCiudadano = dto.idCiudadano,
            idTipoReclamo = dto.idTipoReclamo,
            idUbicacion = dto.idUbicacion,
            idCuadrilla = dto.idCuadrilla
        };

    }
}
