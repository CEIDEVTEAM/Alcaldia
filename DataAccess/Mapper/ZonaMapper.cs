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
        #region ZONA
        public DtoZona MapToDto(Zona entity)
        {
            if (entity == null)
                return null;

            return new DtoZona
            {
                id = entity.id,
                nombre = entity.nombre,
                color = entity.color,
                colVertices = this.MapToDto(entity.Vertice.ToList())
            };
        }

        public Zona MapToEntity(DtoZona dto)
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
        #endregion


        #region VERTICES
        public DtoVertice MapToDto(Vertice entity)
        {
            if (entity == null)
                return null;

            return new DtoVertice
            {

                latitud = entity.latitud.ToString(),
                longitud = entity.longitud.ToString(),
                idZona = entity.idZona,
                orden = (int)entity.orden
            };
        }
        public List<DtoVertice> MapToDto(List<Vertice> ColEnt)
        {
            List<DtoVertice> colDtoVetices = new List<DtoVertice>();

            foreach (Vertice item in ColEnt)
            {
                DtoVertice Dtovert = this.MapToDto(item);
                colDtoVetices.Add(Dtovert);
            }

            return colDtoVetices;

        }

        public List<Vertice> MapToEntity(List<DtoVertice> Coldto)
        {
            List<Vertice> colVetices = new List<Vertice>();
            
            foreach (DtoVertice item in Coldto)
            {
                Vertice vert = this.MaptoEntity(item);
                colVetices.Add(vert);
            }

            return colVetices;
                
        }

        public Vertice MaptoEntity(DtoVertice dto)
        {
            if (dto == null)
                return null;

            return new Vertice
            {

                latitud = dto.latitud,
                longitud = dto.longitud,
                idZona = dto.idZona,
                orden = dto.orden
            };
        }


        #endregion

    }

}
