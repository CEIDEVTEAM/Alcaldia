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

            DtoTipoUsuario DtoTipoUsuario = new DtoTipoUsuario();

            return new DtoUsuario
            {
                nombreDeUsuario = entity.nombreDeUsuario,
                nombre = entity.nombre,
                apellido = entity.apellido,
                contrasenia = entity.contraseña,
                telefono = entity.telefono,
                email = entity.email,
                tipoDeUsuario = this._Tipo_UsuarioMapper.MapToDto(entity.Tipo_Usuario)
            };
        }

        public Usuario MaptoEntity(DtoUsuario dto)
        {

            return new Usuario
            {
                nombreDeUsuario = dto.nombreDeUsuario,
                nombre = dto.nombre,
                apellido = dto.apellido,
                contraseña = dto.contrasenia,
                telefono = dto.telefono,
                email = dto.email,
                tipoDeUsuario = dto.tipoDeUsuario.tipo,
            };
        }
    }
}
