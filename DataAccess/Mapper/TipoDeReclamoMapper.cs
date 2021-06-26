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
                nombre = dto.nombre,
                descripcion = dto.descripcion,
            };
        }

        public List<DtoTipoDeReclamo> MapToDto(List<Tipo_De_Reclamo> colEntity)
        {
            List<DtoTipoDeReclamo> colDto = new List<DtoTipoDeReclamo>();

            foreach (Tipo_De_Reclamo entity in colEntity)
            {
                colDto.Add(this.MaptoDto(entity));
            }

            return colDto;
        }

    }
}
