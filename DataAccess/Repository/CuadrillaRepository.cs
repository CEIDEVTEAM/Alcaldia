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
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Cuadrilla newCuadrilla = this._cuadrillaMapper.MapToEntity(dto);
                        newCuadrilla.situacion = "A";
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
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
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
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
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

        public DtoCuadrilla GetCuadrillaById(int idCuadrilla)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._cuadrillaMapper.MapToDto(context.Cuadrilla.AsNoTracking().FirstOrDefault(f => f.id == idCuadrilla));
        }

        public bool ExistCuadrillaById(int idCuadrilla)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Cuadrilla.AsNoTracking().Any(a => a.id == idCuadrilla);
        }

    }
}

