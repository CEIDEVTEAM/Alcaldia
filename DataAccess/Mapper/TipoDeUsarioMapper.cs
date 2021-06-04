using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TipoDeUsarioMapper
    {
        public Tipo_Usuario MapToEntity(DtoTipoUsuario dto)
        {

            return new Tipo_Usuario
            {
                tipo = dto.tipo,
                descripcion = dto.descripcion

            };

        }

        public DtoTipoUsuario MapToDto(Tipo_Usuario entity)
        {

            return new DtoTipoUsuario
            {
                tipo = entity.tipo,
                descripcion = entity.descripcion

            };

        }
    }
}
