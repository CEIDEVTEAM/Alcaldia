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
   public class VerticeRepository
    {
        private VerticeMapper _verticeMapper;

        public VerticeRepository()
        {
            this._verticeMapper = new VerticeMapper();
        }

        public void AddVertice(DtoVertice dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Vertice newVertice = this._verticeMapper.MaptoEntity(dto);
                        context.Vertice.Add(newVertice);
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

        public void ModifyVertice(DtoVertice dto)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Vertice currVertice = context.Vertice.FirstOrDefault(f => f.id == dto.id);

                        if (currVertice != null)
                        {
                            currVertice.latitud = dto.latitud;
                            currVertice.longitud = dto.longitud;
                            currVertice.idZona = dto.idZona;
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

        public void DeleteVertice(int idVertice)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Vertice currVertice = context.Vertice.FirstOrDefault(f => f.id == idVertice);

                        if (currVertice != null)
                        {
                            context.Vertice.Remove(currVertice);
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

        public DtoVertice GetVerticeById(int idVertice)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return this._verticeMapper.MaptoDto(context.Vertice.AsNoTracking().FirstOrDefault(f => f.id == idVertice));
        }

        public bool ExistVerticeById(int idVertice)
        {
            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
                return context.Vertice.AsNoTracking().Any(a => a.id == idVertice);
        }

    }
}
