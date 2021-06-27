using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class LCuadrillaController
    {
        private Repository _Repository;

        public LCuadrillaController()
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

        public DtoCuadrilla GetCuadrillaById(int id)
        {
            return this._Repository.GetCuadrillaRepository().GetCuadrillaById(id);
        }

        public List<DtoCuadrilla> GetAllCuadrillas()
        {
            return this._Repository.GetCuadrillaRepository().GetAllCuadrillas();
        }

        public List<string> ValidateCuadrilla(DtoCuadrilla dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetCuadrillaRepository().ExistCuadrillaById(dto.id))
                colerrors.Add("La Cuadrilla no existe.");
            if (dto.idZona != null && !this._Repository.GetZonaRepository().ExistZonaById(dto.idZona ?? -1))
                colerrors.Add("La Zona asignada no existe");
            return colerrors;
        }

    }
}
