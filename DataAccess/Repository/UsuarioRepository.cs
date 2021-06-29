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
                        newUsuario.situacion = "A";
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
                        Usuario currUsuario = context.Usuario.FirstOrDefault(f => f.nombreDeUsuario == dto.nombreDeUsuario);

                        if (currUsuario != null)
                        {

                            currUsuario.nombre = dto.nombre;
                            currUsuario.apellido = dto.apellido;
                            currUsuario.contrasenia = dto.contrasenia;
                            currUsuario.telefono = dto.telefono;
                            currUsuario.email = dto.email;
                            currUsuario.situacion = dto.situacion;
                            currUsuario.tipoDeUsuario = dto.tipoDeUsuario.tipo;
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
                        currUsuario.situacion = "I";
                        
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

        public List<DtoUsuario> GetAllUsuario()
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._usuarioMapper.MapToDto(context.Usuario.AsNoTracking().Where(w => w.situacion =="A").Select(s => s).ToList());

        }

        public DtoUsuario GetUsuarioByName(string nombreUsuario)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._usuarioMapper.MaptoDto(context.Usuario.AsNoTracking().FirstOrDefault(f => f.nombreDeUsuario == nombreUsuario));
        }
      

        public bool ExistUsuarioByName(string nombreUsuario)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Usuario.AsNoTracking().Any(a => a.nombreDeUsuario == nombreUsuario);
        }
    }
    

}

