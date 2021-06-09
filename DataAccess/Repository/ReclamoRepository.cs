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
    public class ReclamoRepository
    {
        private ReclamoMapper _ReclamoMapper;

        public ReclamoRepository()
        {
            this._ReclamoMapper = new ReclamoMapper();
        }

        public void AddReclamo(DtoReclamo dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Reclamo newReclamo = this._ReclamoMapper.MaptoEntity(dto);
                        context.Reclamo.Add(newReclamo);
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

        //FALTA TERMINAR MODIFYRECLAMO - VER TEMA DEL ENUM
        public void ModifyReclamo(DtoReclamo dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Reclamo currReclamo = context.Reclamo.FirstOrDefault(f => f.id == dto.id);

                        if (currReclamo != null)
                        {
                            
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

        public void DeleteReclamo(DtoReclamo dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Reclamo currReclamo = context.Reclamo.FirstOrDefault(f => f.id == dto.id);

                        if (currReclamo != null)
                        {
                            context.Reclamo.Remove(currReclamo);
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

        public DtoReclamo GetReclamoById(int idReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._ReclamoMapper.MaptoDto(context.Reclamo.AsNoTracking().FirstOrDefault(f => f.id == idReclamo));
        }

        public bool ExistReclamoById(int idReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Reclamo.AsNoTracking().Any(a => a.id == idReclamo);
        }
    }
}
