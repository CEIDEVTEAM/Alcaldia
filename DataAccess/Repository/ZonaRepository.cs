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
  public class ZonaRepository
    {
        private ZonaMapper _zonaMapper;

        public ZonaRepository()
        {
            this._zonaMapper = new ZonaMapper();
        }

        public void AddZona(DtoZona dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Zona newZona = this._zonaMapper.MapToEntity(dto);
                        newZona.situacion = CGlobals.ESTADO_ACTIVO;
                        context.Zona.Add(newZona);
                        context.SaveChanges();

                        foreach (DtoVertice item in dto.colVertices)
                        {
                            Vertice vertice = this._zonaMapper.MaptoEntity(item);
                            vertice.idZona = newZona.id;
                            context.Vertice.Add(vertice);
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

        public void ModifyZona(DtoZona dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Zona currZona= context.Zona.FirstOrDefault(f => f.id == dto.id);

                        if (currZona != null)
                        {
                            currZona.nombre = dto.nombre;
                            currZona.color = dto.color;
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

        public void DeleteZona(int idZona)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Zona currZona = context.Zona.FirstOrDefault(f => f.id == idZona);

                        if (currZona != null)
                        {
                            context.Zona.Remove(currZona);
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

        public List<DtoZona> GetAllZonas()
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._zonaMapper.MapToDto(context.Zona.Include("Vertice").AsNoTracking().Where(w => w.situacion == CGlobals.ESTADO_ACTIVO).ToList());
        }

        public DtoZona GetZonaById(int idZona)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._zonaMapper.MapToDto(context.Zona.AsNoTracking().FirstOrDefault(f => f.id == idZona));
        }

        public bool ExistZonaById(int idZona)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Zona.AsNoTracking().Any(a => a.id == idZona && a.situacion == CGlobals.ESTADO_ACTIVO);
        }

    }
}
