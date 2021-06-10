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
   public class LogReclamoRepository
    {
        private LogReclamoMapper _logReclamoMapper;

        public LogReclamoRepository()
        {
            this._logReclamoMapper = new LogReclamoMapper();
        }

        public void AddLogReclamo(DtoLogReclamo dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        LogReclamo newLogReclamo = this._logReclamoMapper.MapToEntity(dto);
                        context.LogReclamo.Add(newLogReclamo);
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

        public void ModifyLogReclamo(DtoLogReclamo dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        LogReclamo newLogReclamo = context.LogReclamo.FirstOrDefault(f => f.idLog == dto.idLog);

                        if (newLogReclamo != null)
                        {
                            newLogReclamo.estadoLog = dto.estadoLog;
                            newLogReclamo.fechaYhoraLog = dto.fechaYhoraLog;
                            newLogReclamo.observacionesCuadrilla = dto.observacionesCuadrilla;
                            newLogReclamo.comentarioLog = dto.comentarioLog;
                            newLogReclamo.idReclamo = dto.idReclamo;
                            newLogReclamo.nombreDeUsuario = dto.nombreDeUsuario;
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

        public void DeleteLogReclamo(int idLogReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        LogReclamo currLogReclamo = context.LogReclamo.FirstOrDefault(f => f.idLog == idLogReclamo);

                        if (currLogReclamo != null)
                        {
                            context.LogReclamo.Remove(currLogReclamo);
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

        public DtoLogReclamo GetLogReclamoById(int idLogReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._logReclamoMapper.MapToDto(context.LogReclamo.AsNoTracking().FirstOrDefault(f => f.idLog == idLogReclamo));
        }

        public bool ExistLogReclamoById(int idLogReclamo)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.LogReclamo.AsNoTracking().Any(a => a.idLog == idLogReclamo);
        }
    }
}
