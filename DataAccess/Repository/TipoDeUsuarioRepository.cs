using CommonSolution.DTOs;
using DataAccess.Mapper;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TipoDeUsuarioRepository
    {
        private TipoDeUsarioMapper _TipoDeUsusarioMapper;

        public TipoDeUsuarioRepository()
        {
            this._TipoDeUsusarioMapper = new TipoDeUsarioMapper();
        }


        public void AddUserType(DtoTipoUsuario dto)
        {

            using (ReclamosAlcaldia context = new ReclamosAlcaldia())
            {
                using (DbContextTransaction trann = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Tipo_Usuario newUserType = this._TipoDeUsusarioMapper.MapToEntity(dto);
                        context.Tipo_Usuario.Add(newUserType);
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
