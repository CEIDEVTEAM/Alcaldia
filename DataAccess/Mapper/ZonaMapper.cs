using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ZonaMapper
    {
        public DtoZona MapToDto(Zona entity)
        {
            if (entity == null)
                return null;

            return new DtoZona
            {
                id = entity.id,
                nombre = entity.nombre,
                color = entity.color
            };
        }

        public Zona MaptoEntity(DtoZona dto)
        {
            if (dto == null)
                return null;

            return new Zona
            {
                id = dto.id,
                nombre = dto.nombre,
                color = dto.color,
            };
        }

        public List<DtoZona> MapToDto(List<Zona> colEntity)
        {
            List<DtoZona> colDto = new List<DtoZona>();

            foreach (Zona entity in colEntity)
            {
                colDto.Add(this.MapToDto(entity));
            }

            return colDto;
        }
    }

}
