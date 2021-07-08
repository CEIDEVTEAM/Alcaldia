using CommonSolution.DTOs;
using CommonSolution.ENUMs;
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
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
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

        public void ModifyReclamo(DtoReclamo dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
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
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Reclamo currReclamo = context.Reclamo.FirstOrDefault(f => f.idCiudadano == dto.idCiudadano && f.estado == EnumEstado.PENDIENTE.ToString());
                        if (currReclamo != null)
                        {
                            currReclamo.estado = EnumEstado.DESESTIMADO.ToString();

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

        public DtoReclamo GetReclamoById(int idReclamo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._ReclamoMapper.MaptoDto(context.Reclamo.AsNoTracking().FirstOrDefault(f => f.id == idReclamo));
        }

        public bool ExistReclamoById(int idReclamo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Reclamo.AsNoTracking().Any(a => a.id == idReclamo);
        }

        public List<DtoReclamo> GetAllReclamos()
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                colReclamos = this._ReclamoMapper.MapToDto(context.Reclamo.AsNoTracking().ToList());
            }

            return colReclamos;
        }

        public List<DtoReclamo> GetAllReclamosByUser(string user)
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                colReclamos = this._ReclamoMapper.MapToDto(context.Reclamo.AsNoTracking().Where(w => w.idCiudadano == user).OrderByDescending(o => o.id).ToList());
                
            }

            return colReclamos;
        }

        public List<DtoReclamo> GetAllReclamosByFechasYestado(DtoReclamo dto)
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                colReclamos = this._ReclamoMapper.MapToDto(context.Reclamo.AsNoTracking().Where(w => w.fechaYhora >= dto.fechaInicial &&
                w.fechaYhora <= dto.fechaFinal && w.estado == dto.estado.ToString()).ToList());

            }

            return colReclamos;
        }

        public List<DtoReclamo> GetAllReclamosActivos()
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                colReclamos = this._ReclamoMapper.MapToDto(context.Reclamo.AsNoTracking().Where(w => w.estado == EnumEstado.ASIGNADO.ToString() ||
                w.estado == EnumEstado.PENDIENTE.ToString() || w.estado == EnumEstado.EN_PROCESO.ToString()).ToList());
            }

            return colReclamos;
        }

        public List<DtoReclamo> GetAllReclamosActivosPorCuadrilla(int idCuadrilla)
        {
            List<DtoReclamo> colReclamos = new List<DtoReclamo>();
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                colReclamos = this._ReclamoMapper.MapToDto(context.Reclamo.AsNoTracking().Where(w => w.idCuadrilla == idCuadrilla && 
                w.estado == EnumEstado.ASIGNADO.ToString()
                || w.estado == EnumEstado.EN_PROCESO.ToString()).ToList());
            }

            return colReclamos;
        }
    }
}
