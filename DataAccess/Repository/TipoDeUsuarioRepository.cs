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
    public class TipoDeUsuarioRepository
    {
        private TipoDeUsuarioMapper _TipoDeUsusarioMapper;

        public TipoDeUsuarioRepository()
        {
            this._TipoDeUsusarioMapper = new TipoDeUsuarioMapper();
        }

        public void AddTipoUsuario(DtoTipoUsuario dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_Usuario newTipoUsuario = this._TipoDeUsusarioMapper.MapToEntity(dto);
                        newTipoUsuario.tipo.ToUpper();
                        context.Tipo_Usuario.Add(newTipoUsuario);
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

        public void ModifyTipoUsuario(DtoTipoUsuario dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_Usuario currTipoUsuario = context.Tipo_Usuario.FirstOrDefault(f => f.tipo == dto.tipo);

                        if (currTipoUsuario != null)
                        {
                            currTipoUsuario.descripcion = dto.descripcion;
                        }

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

        public void DeleteTipoUsuario(DtoTipoUsuario dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_Usuario currTipoUsuario = context.Tipo_Usuario.FirstOrDefault(f => f.tipo == dto.tipo);

                        if (currTipoUsuario != null)
                        {
                            context.Tipo_Usuario.Remove(currTipoUsuario);
                            context.SaveChanges();
                            trann.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        trann.Rollback();
                    }
                }
            }
        }

        public DtoTipoUsuario GetTipoUsuarioById(string tipo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._TipoDeUsusarioMapper.MapToDto(context.Tipo_Usuario.AsNoTracking().FirstOrDefault(f => f.tipo == tipo.ToUpper()));
        }

        public bool ExistTipoDeUsuarioById(string tipo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Tipo_Usuario.AsNoTracking().Any(a => a.tipo == tipo.ToUpper());
        }
    }
}
