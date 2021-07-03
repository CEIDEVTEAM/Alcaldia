using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class LTipoDeReclamoController
    {
        private Repository _Repository;

        public LTipoDeReclamoController()
        {
            this._Repository = new Repository();
        }


        public List<string> AddTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            List<string> colerrors = this.ValidateTipoDeReclamo(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetTipoDeReclamoRepository().AddTipoDeReclamo(dto);
            }

            return colerrors;
        }

        public List<string> ModifyTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            List<string> colerrors = this.ValidateTipoDeReclamo(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetTipoDeReclamoRepository().ModifyTipoDeReclamo(dto);
            }

            return colerrors;
        }

        public List<string> DeleteTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            List<string> colerrors = this.ValidateTipoDeReclamo(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetTipoDeReclamoRepository().DeleteTipoDeReclamo(dto.nombre);
            }

            return colerrors;
        }

        public DtoTipoDeReclamo GetTipoDeReclamoByName(string nombre)
        {
            return this._Repository.GetTipoDeReclamoRepository().GetTipoDeReclamoByName(nombre);
        }

        public List<DtoTipoDeReclamo> GetAllTipoDeReclamo()
        {
            return this._Repository.GetTipoDeReclamoRepository().GetAllTipoDeReclamo();
        }


        public List<string> ValidateTipoDeReclamo(DtoTipoDeReclamo dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetTipoDeReclamoRepository().ExistTipoDeReclamoByNombre(dto.nombre))
                colerrors.Add("El Tipo de Reclamo no existe.");

            return colerrors;
        }

        #region VALIDATIONS FRONTEND
        public bool ExistTipoDeReclamoByNombre(string name)
        {
            return this._Repository.GetTipoDeReclamoRepository().ExistTipoDeReclamoByNombre(name);
        }

        #endregion

    }
}
