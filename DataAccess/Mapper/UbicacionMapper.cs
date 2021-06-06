using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public dtoUbicacion toDto(Ubicacion entity)
    {

        return new dtoUbicacion
        {

            id = entity.id,
            latitud = entity.latitud,
            longitud = entity.longitud,
            idZona = entity.idZona,

        };
    }

    public Ubicacion toEntity(dtoUbicacion dto)
    {

        return new Ubicacion
        {

            id = dto.id,
            latitud = dto.latitud,
            longitud = dto.longitud,
            idZona = dto.idZona,

        };
    }
