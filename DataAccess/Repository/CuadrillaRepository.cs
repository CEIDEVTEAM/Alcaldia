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
    public class CuadrillaRepository
    {
        private CuadrillaMapper _cuadrillaMapper;

        public CuadrillaRepository()
        {
            this._cuadrillaMapper = new CuadrillaMapper();
        }

        public void AddCuadrilla(DtoCuadrilla dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Cuadrilla newCuadrilla = this._cuadrillaMapper.MapToEntity(dto);
                        newCuadrilla.situacion = CGlobals.ESTADO_ACTIVO;
                        context.Cuadrilla.Add(newCuadrilla);
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

        public void ModifyCuadrilla(DtoCuadrilla dto)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Cuadrilla currCuadrilla = context.Cuadrilla.FirstOrDefault(f => f.id == dto.id);

                        if (currCuadrilla != null)
                        {
                            currCuadrilla.nombre = dto.nombre;
                            currCuadrilla.encargado = dto.encargado;
                            currCuadrilla.cantidadDePeones = dto.cantidadDePeones;
                            currCuadrilla.idZona = dto.idZona;
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



        public void DeleteCuadrilla(int idCuadrilla)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Cuadrilla currCuadrilla = context.Cuadrilla.FirstOrDefault(f => f.id == idCuadrilla);

                        if (currCuadrilla != null)
                        {
                            context.Cuadrilla.Remove(currCuadrilla);
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


        public List<DtoCuadrilla> GetAllCuadrillas()
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._cuadrillaMapper.MapToDto(context.Cuadrilla.AsNoTracking().Where(w => w.situacion == CGlobals.ESTADO_ACTIVO).ToList());
        }

        public DtoCuadrilla GetCuadrillaById(int idCuadrilla)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._cuadrillaMapper.MapToDto(context.Cuadrilla.AsNoTracking().FirstOrDefault(f => f.id == idCuadrilla));
        }

        public bool ExistCuadrillaById(int idCuadrilla)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Cuadrilla.AsNoTracking().Any(a => a.id == idCuadrilla);
        }
        public bool ExistCuadrillaByName(string name)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Cuadrilla.AsNoTracking().Any(a => a.nombre == name);
        }
        public bool ExistCuadrillaByNameAndId(string name, int id)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Cuadrilla.AsNoTracking().Any(a => a.nombre == name && a.id == id);
        }
        public int GetCuadrillaForReclamo(int idZona)
        {
            int nroCuadrilla = 0;
            List<V_ReclamosAbiertosPorCuadrilla> colZonas = new List<V_ReclamosAbiertosPorCuadrilla>();
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                colZonas = context.V_ReclamosAbiertosPorCuadrilla.AsNoTracking().Where(w => w.idZona == idZona).OrderBy(o => o.cantidad).ToList();

                if (colZonas.FirstOrDefault() != null)
                    nroCuadrilla = colZonas.FirstOrDefault().idCuadrilla;
            }


            return nroCuadrilla;
        }

        public List<DtoCuadrilla> GetCuadrillasWithAvg()
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._cuadrillaMapper.MapToDto(context.V_ReclamosResueltosPorCuadrilla.AsNoTracking().Select(s => s).ToList());
        }
    }
}

