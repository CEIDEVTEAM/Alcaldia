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
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_De_Reclamo newTipoDeReclamo = this._TipoDeReclamoMapper.MaptoEntity(dto);
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
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_De_Reclamo currTipoDeReclamo = context.Tipo_De_Reclamo.FirstOrDefault(f => f.id == dto.id);

                        if (currTipoDeReclamo != null)
                        {
                            currTipoDeReclamo.nombre = dto.nombre;
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

        public void DeleteTipoDeReclamo(int idTipoDeReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_De_Reclamo currTipoDeReclamo = context.Tipo_De_Reclamo.FirstOrDefault(f => f.id == idTipoDeReclamo);

                        if (currTipoDeReclamo != null)
                        {
                            context.Tipo_De_Reclamo.Remove(currTipoDeReclamo);
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

        public DtoTipoDeReclamo GetTipoDeReclamoById(int idTipoDeReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._TipoDeReclamoMapper.MaptoDto(context.Tipo_De_Reclamo.AsNoTracking().FirstOrDefault(f => f.id == idTipoDeReclamo));
        }

        public bool ExistTipoDeReclamoById(int idTipoDeReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Tipo_De_Reclamo.AsNoTracking().Any(a => a.id == idTipoDeReclamo);
        }


    }
}
