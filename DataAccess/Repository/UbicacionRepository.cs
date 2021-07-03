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
    public class UbicacionRepository
    {
        private UbicacionMapper _UbicacionMapper;

        public UbicacionRepository()
        {
            this._UbicacionMapper = new UbicacionMapper();
        }

        public void AddUbicacion(DtoUbicacion dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Ubicacion newUbicacion = this._UbicacionMapper.MaptoEntity(dto);
                        context.Ubicacion.Add(newUbicacion);
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

        public void ModifyUbicacion(DtoUbicacion dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Ubicacion currUbicacion = context.Ubicacion.FirstOrDefault(f => f.latitud == dto.latitud && f.longitud == dto.longitud);
                        
                        if(currUbicacion != null)
                        {
                            currUbicacion.idZona = dto.idZona;
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

        public void DeleteUbicacion(DtoUbicacion dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Ubicacion currUbicacion = context.Ubicacion.FirstOrDefault(f => f.latitud == dto.latitud && f.longitud == dto.longitud);

                        if (currUbicacion != null)
                        {
                            context.Ubicacion.Remove(currUbicacion);
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

        public DtoUbicacion GetUbicacionByLatAndLon(string lat, string lon)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._UbicacionMapper.MaptoDto(context.Ubicacion.AsNoTracking().FirstOrDefault(f => f.latitud == lat && f.longitud == lon));
        }
        public bool ExistUbicacionByLatAndLon(string lat, string lon)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Ubicacion.AsNoTracking().Any(a => a.latitud == lat && a.longitud == lon);
        }
    }
}
