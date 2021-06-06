using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    class TipoDeReclamoMapper
    {
        public dtoTipoDeReclamo toDto(TipoDeReclamo entity)
        {

            return new dtoTipoDeReclamo
            {

                id = entity.id,
                nombre = entity.nombre,
                descripcion = entity.descripcion,

            };
        }
        public TipoDeReclamo toEntity(dtoTipoDeReclamo dto)
        {

            return new TipoDeReclamo
            {

                id = dto.id,
                nombre = dto.nombre,
                descripcion = dto.descripcion,

            };

        }

    }
