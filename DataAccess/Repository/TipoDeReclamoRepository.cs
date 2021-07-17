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
    public class TipoDeReclamoRepository
    {
        private TipoDeReclamoMapper _TipoDeReclamoMapper;

        public TipoDeReclamoRepository()
        {
            this._TipoDeReclamoMapper = new TipoDeReclamoMapper();
        }

        public void AddTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_De_Reclamo newTipoDeReclamo = this._TipoDeReclamoMapper.MaptoEntity(dto);
                        newTipoDeReclamo.situacion = CGlobals.ESTADO_ACTIVO;
                        context.Tipo_De_Reclamo.Add(newTipoDeReclamo);
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

        public void ModifyTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_De_Reclamo currTipoDeReclamo = context.Tipo_De_Reclamo.FirstOrDefault(f => f.nombre == dto.nombre);

                        if (currTipoDeReclamo != null)
                        {
                            currTipoDeReclamo.descripcion = dto.descripcion;
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

        public void DeleteTipoDeReclamo(string nameTipoDeReclamo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_De_Reclamo currTipoDeReclamo = context.Tipo_De_Reclamo.FirstOrDefault(f => f.nombre == nameTipoDeReclamo);

                        if (currTipoDeReclamo != null)
                        {
                            currTipoDeReclamo.situacion = CGlobals.ESTADO_INACTIVO;
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

        public List<DtoTipoDeReclamo> GetAllTipoDeReclamo()
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._TipoDeReclamoMapper.MapToDto(context.Tipo_De_Reclamo.AsNoTracking().Where(w => w.situacion == CGlobals.ESTADO_ACTIVO).ToList());
  
        }

        public DtoTipoDeReclamo GetTipoDeReclamoByName(string nameTipoDeReclamo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._TipoDeReclamoMapper.MaptoDto(context.Tipo_De_Reclamo.AsNoTracking().FirstOrDefault(f => f.nombre == nameTipoDeReclamo));
        }

        public bool ExistTipoDeReclamoByNombre(string nameTipoDeReclamo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Tipo_De_Reclamo.AsNoTracking().Any(a => a.nombre == nameTipoDeReclamo);
        }


    }
}
