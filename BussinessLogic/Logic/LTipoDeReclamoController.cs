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

        public List<string> ValidateTipoDeReclamo(DtoTipoDeReclamo dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetTipoDeReclamoRepository().ExistTipoDeReclamoById(dto.nombre))
                colerrors.Add("El Tipo de Reclamo no existe.");

            return colerrors;
        }
    }
}
