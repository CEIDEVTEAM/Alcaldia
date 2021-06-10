using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class ReclamoController
    {
        private Repository _Repository;

        public ReclamoController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddReclamo(DtoReclamo dto)
        {
            List<string> colerrors = this.ValidateReclamo(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetReclamoRepository().AddReclamo(dto);
            }

            return colerrors;
        }

        public List<string> ModifyReclamo(DtoReclamo dto)
        {
            List<string> colerrors = this.ValidateReclamo(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetReclamoRepository().ModifyReclamo(dto);
            }

            return colerrors;
        }

        public List<string> DeleteReclamo(DtoReclamo dto)
        {
            List<string> colerrors = this.ValidateReclamo(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetReclamoRepository().DeleteReclamo(dto);
            }

            return colerrors;
        }

        public List<string> ValidateReclamo(DtoReclamo dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetReclamoRepository().ExistReclamoById(dto.id))
                colerrors.Add("El Reclamo no existe.");

            return colerrors;
        }

    }
}
