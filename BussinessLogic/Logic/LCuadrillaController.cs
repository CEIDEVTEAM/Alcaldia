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

            if (this._Repository.GetReclamoRepository().ExistenReclamosParaCuadilla(dto.id))
                colerrors.Add("Cuadrilla NO se ha dado de baja, tiene reclamos activos");

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

        public bool ExistCuadrillaByName(string name)
        {
            return this._Repository.GetCuadrillaRepository().ExistCuadrillaByName(name);
        }

        public List<DtoCuadrilla> GetCuadrillasWithAvg()
        {
            List<DtoCuadrilla> colDto = new List<DtoCuadrilla>();
            colDto = this._Repository.GetCuadrillaRepository().GetCuadrillasWithAvg();
            foreach (DtoCuadrilla item in colDto)
            {
                item.promedioNum = item.totalMin ?? 0 / item.totalMin ?? 1;
                int totMin = item.totalMin ?? 0;
                int days = totMin / 1440;
                int hours = (totMin % 1440) / 60;
                int mins = totMin % 60;

                item.promedioStg = string.Format(@"{0} Dia/s, {1} Hora/s, {2} Minutos", days, hours, mins);
            }
            colDto = colDto.Where(w => w.situacion == CGlobals.ESTADO_ACTIVO).OrderBy(o => o.promedioNum).ToList();

            return colDto;
        }

        public bool ExistCuadrillaByNameAndId(string name, int id)
        {
            return this._Repository.GetCuadrillaRepository().ExistCuadrillaByNameAndId(name, id);
        }
    }
}
