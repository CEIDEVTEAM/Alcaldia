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


        public void AddUserType(DtoTipoUsuario dto)
        {
           
            this._Repository.GetTipoDeUsuarioRepository().AddUserType(dto);
        
        }


    }
}
