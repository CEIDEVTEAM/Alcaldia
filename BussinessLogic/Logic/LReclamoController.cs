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
    public class LReclamoController
    {
        private Repository _Repository;

        public LReclamoController()
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


        public List<DtoVertice> GetAllUbicacionesReclamos()
        {
            List<DtoReclamo> colReclamos = this.GetAllReclamos();
            return this.MapReclamosToVertices(colReclamos);
        }

        public List<DtoVertice> GetAllUbicacionesReclamos(DateTime fechaInicial, DateTime fechaFinal)
        {
            List<DtoReclamo> colReclamos = this._Repository.GetReclamoRepository().GetAllReclamos(fechaInicial, fechaFinal);
            return this.MapReclamosToVertices(colReclamos);
        }

        public List<DtoVertice> MapReclamosToVertices(List<DtoReclamo> colReclamos)
        {
            List<DtoVertice> colUbicaciones = new List<DtoVertice>();

            foreach (DtoReclamo item in colReclamos)
            {
                DtoVertice vert = new DtoVertice();
                vert.latitud = item.LatitudReclamo;
                vert.longitud = item.LongitudReclamo;
                colUbicaciones.Add(vert);
            }

            return colUbicaciones;
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
            if (isAdd == true && dto.observaciones == null)
            {
                colerrors.Add("El valor no puede ser nulo");
                return colerrors;
            }
            if (isAdd == true && dto.nombreTipoReclamo == null)
            {
                colerrors.Add("El valor no puede ser nulo");
                return colerrors;
            }
            if (isAdd == false && !this._Repository.GetReclamoRepository().ExistReclamoById(dto.id))
                colerrors.Add("El Reclamo no existe.");

            return colerrors;
        }

        public void CuadrillaForReclamo(DtoReclamo dto)
        {
            int currCuadrilla = this._Repository.GetCuadrillaRepository().GetCuadrillaForReclamo(dto.idZona);
            if (currCuadrilla != 0)
            {
                dto.idCuadrilla = currCuadrilla;
                dto.estado = CommonSolution.ENUMs.EnumEstado.ASIGNADO;
            }

        }
        public DtoReclamo GetReclamoById(int idReclamo)
        {
            return this._Repository.GetReclamoRepository().GetReclamoById(idReclamo);
        }

        public List<DtoReclamo> GetAllReclamosByUser(string user)
        {
            return this._Repository.GetReclamoRepository().GetAllReclamosByUser(user);

        }
        public List<DtoReclamo> GetAllReclamos()
        {
            return this._Repository.GetReclamoRepository().GetAllReclamos();

        }

        public List<DtoReclamo> GetAllReclamosByFechaYestado(DtoReclamo dto)
        {

            return this._Repository.GetReclamoRepository().GetAllReclamosByFechasYestado(dto);

        }

        public List<DtoReclamo> GetAllReclamosActivosByCuadrilla(int IdCuadrilla)
        {
            List<DtoReclamo> dtoReclamo = this._Repository.GetReclamoRepository().GetAllReclamosActivosPorCuadrilla(IdCuadrilla);
            DateTime today = DateTime.Now;

            foreach (DtoReclamo item in dtoReclamo)
            {
                TimeSpan ret = (TimeSpan)(today - item.fechaYhora);
                string output = string.Format(@"{0} Dias, {1} Horas, {2} Minutos", ret.Days, ret.Hours, ret.Minutes);

                item.tiempoDeRetraso = output;
                item.color = this.GetRetrasoColor(ret);

            }
            return dtoReclamo;

        }

        public List<DtoReclamo> GetReclamoWithRetraso()
        {
            List<DtoReclamo> dtoReclamo = this._Repository.GetReclamoRepository().GetAllReclamosActivos();
            DateTime today = DateTime.Now;

            foreach (DtoReclamo item in dtoReclamo)
            {
                TimeSpan ret = (TimeSpan)(today - item.fechaYhora);
                string output = string.Format(@"{0} Dias, {1} Horas, {2} Minutos", ret.Days, ret.Hours, ret.Minutes);

                item.tiempoDeRetraso = output;
                item.color = this.GetRetrasoColor(ret);

            }

            return dtoReclamo;
        }



        public string GetRetrasoColor(TimeSpan retraso)
        {
            double horasRetraso = retraso.TotalHours;

            if (horasRetraso < CMapColor.LIMIT_GREEN_HOURS)
                return CMapColor.GREEN_COLOR_HEX; //VERDE

            if (horasRetraso >= CMapColor.LIMIT_GREEN_HOURS && horasRetraso <= CMapColor.START_RED_HOURS)
                return CMapColor.YELLOW_COLOR_HEX; //AMARILLO

            return CMapColor.RED_COLOR_HEX; //ROJO
        }
    }
}
