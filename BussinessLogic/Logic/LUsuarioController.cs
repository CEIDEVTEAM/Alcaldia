using CommonSolution.Constants;
using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
   public class LUsuarioController
    {
        private Repository _Repository;

        public LUsuarioController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddUsuarioCiudadano(DtoUsuario dto)
        {
            dto.tipoDeUsuario = this._Repository.GetTipoDeUsuarioRepository().GetTipoUsuarioById(CUsuario.USER_CIUDADANO);
            List<string> colerrors = this.ValidateUsuario(dto, true);

            if (colerrors.Count == 0)
            {
                
                this._Repository.GetUsuarioRepository().AddUsuario(dto);
            }

            return colerrors;
        }
        public List<string> AddUsuarioFuncionario(DtoUsuario dto)
        {
            dto.tipoDeUsuario = this._Repository.GetTipoDeUsuarioRepository().GetTipoUsuarioById(CUsuario.USER_FUNCIONARIO);
            List<string> colerrors = this.ValidateUsuario(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetUsuarioRepository().AddUsuario(dto);
            }

            return colerrors;
        }
        public List<string> ModifyUsuario(DtoUsuario dto)
        {
            List<string> colerrors = this.ValidateUsuario(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetUsuarioRepository().ModifyUsuario(dto);
            }

            return colerrors;
        }
        public bool ValidateCredentialsFuncionario(DtoLogin dto)
        {
            dto.tipoDeUsuario = CUsuario.USER_FUNCIONARIO;
            return this._Repository.GetUsuarioRepository().ValidateLogin(dto);
        }
        public bool ValidateCredentialsCiudadano(DtoLogin dto)
        {
            dto.tipoDeUsuario = CUsuario.USER_CIUDADANO;
            return this._Repository.GetUsuarioRepository().ValidateLogin(dto);
        }
        public List<string> DeleteUsuario(DtoUsuario dto)
        {
            List<string> colerrors = this.ValidateUsuario(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetUsuarioRepository().DeleteUsuario(dto.nombreDeUsuario);
            }

            return colerrors;
        }
        public List<string> ValidateUsuario(DtoUsuario dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetUsuarioRepository().ExistUsuario(dto))
                colerrors.Add("El usuario no existe.");

            if (isAdd == true && this._Repository.GetUsuarioRepository().ExistUsuario(dto))
                colerrors.Add("El usuario ya está registrado.");

            return colerrors;
        }
   
    }
}
