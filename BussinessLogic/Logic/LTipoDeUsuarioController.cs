using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class LTipoDeUsuarioController
    {
        private Repository _Repository;

        public LTipoDeUsuarioController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddTipoDeUsuario(DtoTipoUsuario dto)
        {
            List<string> colerrors = this.ValidateUsuario(dto, true);

            if (colerrors.Count == 0)
            {
                dto.tipo.ToUpper();
                this._Repository.GetTipoDeUsuarioRepository().AddTipoUsuario(dto);
            }

            return colerrors;
        }

        public List<string> ValidateUsuario(DtoTipoUsuario dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == true && this._Repository.GetTipoDeUsuarioRepository().ExistTipoDeUsuarioById(dto.tipo))
                colerrors.Add("El Tipo de Usuario ya existe");

            return colerrors;
        }
    }
}
