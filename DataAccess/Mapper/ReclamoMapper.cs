using CommonSolution.DTOs;
using CommonSolution.ENUMs;
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
            if (entity == null)
                return null;

            return new DtoReclamo
            {
                id = entity.id,
                estado = (EnumEstado)Enum.Parse(typeof(EnumEstado), entity.estado),
                fechaYhora = entity.fechaYhora,
                observaciones = entity.observaciones,
                idCiudadano = entity.idCiudadano,
                nombreTipoReclamo = entity.nombreTipoReclamo,
                LatitudReclamo = entity.LatitudReclamo,
                LongitudReclamo = entity.LongitudReclamo,
                idCuadrilla = entity.idCuadrilla,
                idZona = (int)entity.idZona
            };
        }

        public Reclamo MaptoEntity(DtoReclamo dto)
        {
            if (dto == null)
                return null;

            return new Reclamo
            {
                id = dto.id,
                estado = (dto.estado).ToString(),
                fechaYhora = dto.fechaYhora,
                observaciones = dto.observaciones,
                idCiudadano = dto.idCiudadano,
                nombreTipoReclamo = dto.nombreTipoReclamo,
                LatitudReclamo = dto.LatitudReclamo,
                LongitudReclamo = dto.LongitudReclamo,
                idCuadrilla = dto.idCuadrilla,
                idZona = dto.idZona
            };
        }
    }
}
