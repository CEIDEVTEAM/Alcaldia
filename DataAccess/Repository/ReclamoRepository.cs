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



        //FALTA TERMINAR MODIFYRECLAMO
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
    }
}
