using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TipoDeUsuarioMapper
    {
        public Tipo_Usuario MapToEntity(DtoTipoUsuario dto)
        {
            if (dto == null)
                return null;

            return new Tipo_Usuario
            {
                tipo = dto.tipo,
                descripcion = dto.descripcion
            };
        }

        public DtoTipoUsuario MapToDto(Tipo_Usuario entity)
        {
            if (entity == null)
                return null;

            return new DtoTipoUsuario
            {
                tipo = entity.tipo,
                descripcion = entity.descripcion
            };
        }
    }
}
