using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BussinessLogic.Logic
{
    public class LLogReclamoController
    {
        private Repository _Repository;

        public LLogReclamoController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddLogReclamo(DtoLogReclamo dto)
        {
            List<string> colerrors = this.ValidateLogReclamo(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetLogReclamoRepository().AddLogReclamo(dto);
            }

            return colerrors;
        }

        public List<string> ModifyLogReclamo(DtoLogReclamo dto)
        {
            List<string> colerrors = this.ValidateLogReclamo(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetLogReclamoRepository().ModifyLogReclamo(dto);
            }

            return colerrors;
        }

        public List<string> DeleteLogReclamo(DtoLogReclamo dto)
        {
            List<string> colerrors = this.ValidateLogReclamo(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetLogReclamoRepository().DeleteLogReclamo(dto.idLog);
            }

            return colerrors;
        }

        public List<string> ValidateLogReclamo(DtoLogReclamo dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetLogReclamoRepository().ExistLogReclamoById(dto.idLog))
                colerrors.Add("El LogReclamo no existe.");

            return colerrors;
        }

        public List<DtoLogReclamo> GetLogReclamoById(int id)
        {
            List<DtoLogReclamo> dtoLog = new List<DtoLogReclamo>();
            return dtoLog = this._Repository.GetLogReclamoRepository().GetLogReclamoById(id);
        }
    }
}
