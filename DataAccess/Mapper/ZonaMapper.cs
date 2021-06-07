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
        public DtoZona MaptoDto(Zona entity)
        {

            return new DtoZona
            {
                id = entity.id,
                nombre = entity.nombre,
                color = entity.color
            };
        }

        public Zona MaptoEntity(DtoZona dto)
        {

            return new Zona
            {
                id = dto.id,
                nombre = dto.nombre,
                color = dto.color,
            };
        }
    }

}
