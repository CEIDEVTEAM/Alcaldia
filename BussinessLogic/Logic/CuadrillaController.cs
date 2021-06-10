using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class CuadrillaController
    {
        private Repository _Repository;

        public CuadrillaController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddCuadrilla(DtoCuadrilla dto)
        {
            List<string> colerrors = this.ValidateCuadrilla(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetCuadrillaRepository().AddCuadrilla(dto);
            }

            return colerrors;
        }

        public List<string> ModifyCuadrilla(DtoCuadrilla dto)
        {
            List<string> colerrors = this.ValidateCuadrilla(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetCuadrillaRepository().ModifyCuadrilla(dto);
            }

            return colerrors;
        }

        public List<string> DeleteCuadrilla(DtoCuadrilla dto)
        {
            List<string> colerrors = this.ValidateCuadrilla(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetCuadrillaRepository().DeleteCuadrilla(dto.id);
            }

            return colerrors;
        }

        public List<string> ValidateCuadrilla(DtoCuadrilla dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetCuadrillaRepository().ExistCuadrillaById(dto.id))
                colerrors.Add("La Cuadrilla no existe.");

            return colerrors;
        }

    }
}
