using CommonSolution.Constants;
using CommonSolution.DTOs;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UsuarioRepository
    {
        private UsuarioMapper _usuarioMapper;

        public UsuarioRepository()
        {
            this._usuarioMapper = new UsuarioMapper();
        }

        public void AddUsuario(DtoUsuario dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Usuario newUsuario = this._usuarioMapper.MaptoEntity(dto);
                        newUsuario.situacion = CGlobals.ESTADO_ACTIVO;
                        context.Usuario.Add(newUsuario);
                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public void ModifyUsuario(DtoUsuario dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Usuario currUsuario = context.Usuario.Include("Tipo_Usuario").FirstOrDefault(f => f.nombreDeUsuario == dto.nombreDeUsuario);

                        if (currUsuario != null)
                        {

                            currUsuario.nombre = dto.nombre;
                            currUsuario.apellido = dto.apellido;
                            currUsuario.contrasenia = dto.contrasenia;
                            currUsuario.telefono = dto.telefono;
                            currUsuario.email = dto.email;
                        };

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }


        public void DeleteUsuario(string nombreUsuario)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Usuario currUsuario = context.Usuario.FirstOrDefault(f => f.nombreDeUsuario == nombreUsuario);
                        currUsuario.situacion = CGlobals.ESTADO_INACTIVO;

                        context.SaveChanges();
                        trann.Commit();
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public bool ValidateLogin(DtoLogin dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Usuario.AsNoTracking().Any(a => a.nombreDeUsuario == dto.user && a.contrasenia == dto.pass && a.tipoDeUsuario == dto.tipoDeUsuario);
        }

        public DtoUsuario GetUsuarioByNombre(string nombreUsuario)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._usuarioMapper.MaptoDto(context.Usuario.AsNoTracking().FirstOrDefault(f => f.nombreDeUsuario == nombreUsuario));
        }

        public bool ExistUsuario(DtoUsuario usuario)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Usuario.AsNoTracking().Any(a => a.nombreDeUsuario == usuario.nombreDeUsuario && a.tipoDeUsuario == usuario.tipoDeUsuario.tipo && a.situacion == CGlobals.ESTADO_ACTIVO);
        }
        public bool ExistUsuarioByCredentials(DtoLogin dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Usuario.AsNoTracking().Any(a => a.nombreDeUsuario == dto.user && a.contrasenia == dto.pass && a.tipoDeUsuario == dto.tipoDeUsuario && a.situacion == CGlobals.ESTADO_ACTIVO);
        }
        public List<DtoUsuario> GetAllUsers()
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._usuarioMapper.MapToDto(context.Usuario.AsNoTracking().Where(w => w.situacion == CGlobals.ESTADO_ACTIVO).ToList());

        }
    }



}

