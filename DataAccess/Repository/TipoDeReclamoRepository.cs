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
                        newTipoDeReclamo.situacion = "A";
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
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_De_Reclamo currTipoDeReclamo = context.Tipo_De_Reclamo.FirstOrDefault(f => f.nombre == nameTipoDeReclamo);

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

        public List<DtoTipoDeReclamo> GetAllTipoDeReclamo()
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._TipoDeReclamoMapper.MapToDto(context.Tipo_De_Reclamo.AsNoTracking().Select(s => s).ToList());
  
        }

        public DtoTipoDeReclamo GetTipoDeReclamoByName(string nameTipoDeReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._TipoDeReclamoMapper.MaptoDto(context.Tipo_De_Reclamo.AsNoTracking().FirstOrDefault(f => f.nombre == nameTipoDeReclamo));
        }

        public bool ExistTipoDeReclamoById(string nameTipoDeReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Tipo_De_Reclamo.AsNoTracking().Any(a => a.nombre == nameTipoDeReclamo);
        }


    }
}
