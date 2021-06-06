using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ZonaMapper
    {
        public dtoZona toDto(zona entity)
        {

            return new dtoZona
            {

                id = entity.id,
                nombre = entity.nombre,
                color = entity.color

            };
        }

        public zona toEntity(dtoZona dto)
        {

            return new zona
            {

                id = dto.id,
                nombre = dto.nombre,
                color = dto.color,

            };
        }
    }

}
