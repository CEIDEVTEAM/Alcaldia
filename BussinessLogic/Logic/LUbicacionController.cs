using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class LUbicacionController
    {
        private Repository _Repository;

        public LUbicacionController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddUbicacion(DtoUbicacion dto)
        {
            List<string> colerrors = this.ValidateUbicacion(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetUbicacionRepository().AddUbicacion(dto);
            }

            return colerrors;
        }

        public List<string> ModifyUbicacion(DtoUbicacion dto)
        {
            List<string> colerrors = this.ValidateUbicacion(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetUbicacionRepository().ModifyUbicacion(dto);
            }

            return colerrors;
        }

        public List<string> DeleteTipoDeReclamo(DtoUbicacion dto)
        {
            List<string> colerrors = this.ValidateUbicacion(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetUbicacionRepository().DeleteUbicacion(dto);
            }

            return colerrors;
        }

        public List<string> ValidateUbicacion(DtoUbicacion dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetUbicacionRepository().ExistUbicacionByLatAndLon(dto.latitud, dto.longitud))
                colerrors.Add("La ubicación no existe.");

            if (isAdd == true && this._Repository.GetUbicacionRepository().ExistUbicacionByLatAndLon(dto.latitud, dto.longitud))
                colerrors.Add("La ubicación ya está registrada.");

            return colerrors;
        }

    }
}
