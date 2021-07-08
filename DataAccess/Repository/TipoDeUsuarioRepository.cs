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
    public class TipoDeUsuarioRepository
    {
        private TipoDeUsuarioMapper _TipoDeUsusarioMapper;

        public TipoDeUsuarioRepository()
        {
            this._TipoDeUsusarioMapper = new TipoDeUsuarioMapper();
        }

        public DtoTipoUsuario GetTipoUsuarioById(string tipo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return this._TipoDeUsusarioMapper.MapToDto(context.Tipo_Usuario.AsNoTracking().FirstOrDefault(f => f.tipo == tipo.ToUpper()));
        }

        public bool ExistTipoDeUsuarioById(string tipo)
        {
            using (ReclamosAlcaldiaEntities context = new ReclamosAlcaldiaEntities())
                return context.Tipo_Usuario.AsNoTracking().Any(a => a.tipo == tipo.ToUpper());
        }
    }
}
