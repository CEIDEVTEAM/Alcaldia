using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ReclamoMapper
    {
        public DtoReclamo MaptoDto(Reclamo entity)
        {

            return new DtoReclamo
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

        public Reclamo MaptoEntity(DtoReclamo dto)
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
}
