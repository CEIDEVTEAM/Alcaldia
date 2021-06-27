﻿using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CuadrillaMapper
    {
        public DtoCuadrilla MapToDto(Cuadrilla entity)
        {
            if (entity == null)
                return null;

            return new DtoCuadrilla
            {
                id = entity.id,
                nombre = entity.nombre,
                encargado = entity.encargado,
                idZona = entity.idZona,
                cantidadDePeones = entity.cantidadDePeones
            };
        }

        public Cuadrilla MapToEntity(DtoCuadrilla dto)
        {
            if (dto == null)
                return null;

            return new Cuadrilla
            {
                id = dto.id,
                nombre = dto.nombre,
                encargado = dto.encargado,
                idZona = dto.idZona,
                cantidadDePeones = dto.cantidadDePeones
            };
        }

        public List<DtoCuadrilla> MapToDto(List<Cuadrilla> colEntity)
        {
            List<DtoCuadrilla> colDto = new List<DtoCuadrilla>();

            foreach (Cuadrilla entity in colEntity)
            {
                colDto.Add(this.MapToDto(entity));
            }

            return colDto;
        }
    }
}
