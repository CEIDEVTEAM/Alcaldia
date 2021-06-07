using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class VerticeMapper
    {
        public DtoVertice MaptoDto(Vertice entity)
        {
            if (entity == null)
                return null;

            return new DtoVertice
            {
                id = entity.id,
                latitud = entity.latitud,
                longitud = entity.longitud,
                idZona = entity.idZona
            };
        }

        public Vertice MaptoEntity(DtoVertice dto)
        {
            if (dto == null)
                return null;

            return new Vertice
            {
                id = dto.id,
                latitud = dto.latitud,
                longitud = dto.longitud,
                idZona = dto.idZona
            };
        }
    }
}
