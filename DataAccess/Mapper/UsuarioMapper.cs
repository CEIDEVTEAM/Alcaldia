using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UsuarioMapper
    {
        public dtoUsuario toDto(Usuario entity)
        {


            return new dtoUsuario
            {

                nombreDeUsuario = entity.nombreDeUsuario,
                nombre = entity.nombre,
                apellido = entity.apellido,
                contraseña = entity.contraseña,
                telefono = entity.telefono,
                email = entity.email,
                tipo = entity.tipo,

            };
        }
        public Usuario toEntity(dtoUsuario dto)
        {

            return new Usuario
            {

                nombreDeUsuario = dto.nombreDeUsuario,
                nombre = dto.nombre,
                apellido = dto.apellido,
                contraseña = dto.contraseña,
                telefono = dto.telefono,
                email = dto.email,
                tipo = dto.tipo,

            };


        }
    }
