using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class TipoDeUsuarioController
    {
        private Repository _Repository;

        public TipoDeUsuarioController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddTipoDeUsuario(DtoTipoUsuario dto)
        {
            List<string> colerrors = new List<string>();

            if (colerrors.Count == 0)
            {
                dto.tipo.ToUpper();
                this._Repository.GetTipoDeUsuarioRepository().AddTipoUsuario(dto);
            }

            return colerrors;
        }


        public List<string> ValidateUsuario(DtoTipoUsuario dto)
        {
            List<string> colerrors = new List<string>();

            if (this._Repository.GetTipoDeUsuarioRepository().ExistTipoDeUsuarioById(dto.tipo))
                colerrors.Add("El Tipo de Usuario ya existe");

            return colerrors;
        }
    }
}
