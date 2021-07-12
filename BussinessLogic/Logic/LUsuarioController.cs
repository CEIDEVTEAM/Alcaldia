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

        public string GetCompleteNameByUsuario(string user)
        {
            DtoUsuario usuario = this._Repository.GetUsuarioRepository().GetUsuarioByNombre(user);
            return (usuario != null) ? usuario.nombre + " " + usuario.apellido : "";
        }

        public List<string> ModifyUsuarioFuncionario(DtoUsuario dto)
        {
            dto.tipoDeUsuario = this._Repository.GetTipoDeUsuarioRepository().GetTipoUsuarioById(CUsuario.USER_FUNCIONARIO);
            List<string> colerrors = this.ValidateUsuario(dto, false);


            if (colerrors.Count == 0)
            {
                this._Repository.GetUsuarioRepository().ModifyUsuario(dto);
            }

            return colerrors;
        }

        public bool ExistCredentialsByUserAndPass(DtoLogin dto)
        {
            return this._Repository.GetUsuarioRepository().ExistUsuarioByCredentials(dto);
        }

        public bool ExistUsuarioByNombre(string nombre)
        {
            return this._Repository.GetUsuarioRepository().ExistUsuarioByName(nombre);
        }
        public List<string> ModifyUsuarioCiudadano(DtoUsuario dto)
        {
            dto.tipoDeUsuario = this._Repository.GetTipoDeUsuarioRepository().GetTipoUsuarioById(CUsuario.USER_CIUDADANO);
            List<string> colerrors = this.ValidateUsuario(dto, false);


            if (colerrors.Count == 0)
            {
                this._Repository.GetUsuarioRepository().ModifyUsuario(dto);
            }

            return colerrors;
        }

        public void ModifyPassword(DtoChangePass dto)
        {
            this._Repository.GetUsuarioRepository().ModifyPassword(dto);
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
        public List<DtoUsuario> GetAllUsers()
        {
            return this._Repository.GetUsuarioRepository().GetAllUsers();
        }
        public DtoUsuario GetUserByNombre(string nombreUsuario)
        {
            return this._Repository.GetUsuarioRepository().GetUsuarioByNombre(nombreUsuario);
        }

    }
}
