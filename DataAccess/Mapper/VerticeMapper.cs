using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class VerticeMapper
    {
        public dtoVertice toDto(Vertice entity)
        {

            return new dtoVertice
            {

                id = entity.id,
                latitud = entity.latitud,
                longitud = entity.longitud,
                idZona = entity.idZona

            };
        }
        public Vertice toEntity(dtoVertice dto)
        {

            return new Vertice
            {

                id = dto.id,
                latitud = dto.latitud,
                longitud = dto.longitud,
                idZona = dto.idZona

            };
        }
    }
