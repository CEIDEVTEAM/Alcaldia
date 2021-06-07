using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TipoDeReclamoMapper
    {
        public DtoTipoDeReclamo MaptoDto(Tipo_De_Reclamo entity)
        {
            if (entity == null)
                return null;

            return new DtoTipoDeReclamo
            {
                id = entity.id,
                nombre = entity.nombre,
                descripcion = entity.descripcion,
            };
        }

        public Tipo_De_Reclamo MaptoEntity(DtoTipoDeReclamo dto)
        {
            if (dto == null)
                return null;

            return new Tipo_De_Reclamo
            {
                id = dto.id,
                nombre = dto.nombre,
                descripcion = dto.descripcion,
            };
        }
    }
}
