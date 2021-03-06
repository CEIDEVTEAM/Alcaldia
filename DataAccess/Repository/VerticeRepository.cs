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
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
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
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Vertice currVertice = context.Vertice.FirstOrDefault(f => f.latitud == dto.latitud && f.longitud == dto.longitud);

                        if (currVertice != null)
                        {
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

        public void DeleteVertice(string lat, string lon)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Vertice currVertice = context.Vertice.FirstOrDefault(f => f.latitud == lat && f.longitud == lon);

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

        public DtoVertice GetVerticeByLatAndLon(string lat, string lon)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._verticeMapper.MaptoDto(context.Vertice.AsNoTracking().FirstOrDefault(f => f.latitud == lat && f.longitud == lon));
        }

        public bool ExistVerticeByLatAndLon(string lat, string lon)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Vertice.AsNoTracking().Any(f => f.latitud == lat && f.longitud == lon);
        }

    }
}
