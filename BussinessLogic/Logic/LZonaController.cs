using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class LZonaController
    {
        private Repository _Repository;

        public LZonaController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddZona(DtoZona dto)
        {
            List<string> colerrors = this.ValidateZona(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetZonaRepository().AddZona(dto);
            }

            return colerrors;
        }

        public List<string> ModifyZona(DtoZona dto)
        {
            List<string> colerrors = this.ValidateZona(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetZonaRepository().ModifyZona(dto);
            }

            return colerrors;
        }

        public List<DtoZona> GetAllZonas()
        {
            List<DtoZona> colDto = new List<DtoZona>();
            colDto = this._Repository.GetZonaRepository().GetAllZonas();
            foreach (DtoZona item in colDto)
            {
                item.reclamosActivos = this._Repository.GetZonaRepository().GetReclamosActivosZona(item.id);
            }

            return colDto;
        }

        public List<string> DeleteZona(DtoZona dto)
        {
            List<string> colerrors = this.ValidateZona(dto, false);
            int recAct = this._Repository.GetZonaRepository().GetReclamosActivosZona(dto.id);
            
            if (recAct > 0)
                colerrors.Add("No se pueden eliminar zonas con reclamos activos");

            if (colerrors.Count == 0)
            {
                List<DtoCuadrilla> dtoCuadrillas = this._Repository.GetCuadrillaRepository().GetCuadrillaByZona(dto.id);
                this._Repository.GetZonaRepository().DeleteZona(dto.id);
                foreach (DtoCuadrilla item in dtoCuadrillas)
                {
                    this._Repository.GetCuadrillaRepository().RemoveZonaToCuadrilla(item.id);
                }
                
            }

            return colerrors;
        }

        public DtoZona GetZonaByNombre(string nombreZona)
        {
            return this._Repository.GetZonaRepository().GetZonaByNombre(nombreZona);
        }

        public DtoZona GetZonaById(int idZona)
        {
            return this._Repository.GetZonaRepository().GetZonaById(idZona);
        }

        public List<string> ValidateZona(DtoZona dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (dto.nombre == null)
            {
                colerrors.Add("El nombre no puede ser nulo");
                return colerrors;
            }
            if (isAdd && dto.colVertices.Count < 3)
                colerrors.Add("No hay markers suficientes para generar la zona.");
            if (isAdd && this._Repository.GetZonaRepository().ExistZonaByNombre(dto.nombre))
                colerrors.Add("El nombre ya existe, ingrese otro.");

            return colerrors;
        }




        public bool ExisteZonaByNombre(string name)
        {
            return this._Repository.GetZonaRepository().ExistZonaByNombre(name);
        }
    }
}
