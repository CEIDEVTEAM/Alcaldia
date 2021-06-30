using CommonSolution.DTOs;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UsuarioMapper
    {
        private TipoDeUsuarioMapper _Tipo_UsuarioMapper;

        public UsuarioMapper()
        {
            this._Tipo_UsuarioMapper = new TipoDeUsuarioMapper();
        }


        public DtoUsuario MaptoDto(Usuario entity)
        {
            if (entity == null)
                return null;

            DtoTipoUsuario DtoTipoUsuario = new DtoTipoUsuario();

            return new DtoUsuario
            {
                nombreDeUsuario = entity.nombreDeUsuario,
                nombre = entity.nombre,
                apellido = entity.apellido,
                contrasenia = entity.contrasenia,
                telefono = entity.telefono,
                email = entity.email,
                situacion = entity.situacion,
                tipoDeUsuario = this._Tipo_UsuarioMapper.MapToDto(entity.Tipo_Usuario)
            };
        }

        public Usuario MaptoEntity(DtoUsuario dto)
        {
            if (dto == null)
                return null;

            return new Usuario
            {
                nombreDeUsuario = dto.nombreDeUsuario,
                nombre = dto.nombre,
                apellido = dto.apellido,
                contrasenia = dto.contrasenia,
                telefono = dto.telefono,
                email = dto.email,
                tipoDeUsuario = dto.tipoDeUsuario.tipo
            };
        }
        public List<DtoUsuario> MapToDto(List<Usuario> colEntity)
        {
            List<DtoUsuario> colDto = new List<DtoUsuario>();

            foreach (Usuario entity in colEntity)
            {
                colDto.Add(this.MaptoDto(entity));
            }

            return colDto;
        }
    }
}
