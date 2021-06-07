using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UbicacionMapper
    {
        public DtoUbicacion MaptoDto(Ubicacion entity)
        {
            if (entity == null)
                return null;

            return new DtoUbicacion
            {
                id = entity.id,
                latitud = entity.latitud,
                longitud = entity.longitud,
                idZona = entity.idZona,
            };
        }

        public Ubicacion MaptoEntity(DtoUbicacion dto)
        {
            if (dto == null)
                return null;

            return new Ubicacion
            {
                id = dto.id,
                latitud = dto.latitud,
                longitud = dto.longitud,
                idZona = dto.idZona,
            };
        }
    }
}