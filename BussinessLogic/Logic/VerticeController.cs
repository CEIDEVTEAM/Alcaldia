using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
   public class VerticeController
    {
        private Repository _Repository;

        public VerticeController()
        {
            this._Repository = new Repository();
        }

        public List<string> AddVertice(DtoVertice dto)
        {
            List<string> colerrors = this.ValidateVertice(dto, true);

            if (colerrors.Count == 0)
            {
                this._Repository.GetVerticeRepository().AddVertice(dto);
            }

            return colerrors;
        }

        public List<string> ModifyVertice(DtoVertice dto)
        {
            List<string> colerrors = this.ValidateVertice(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetVerticeRepository().ModifyVertice(dto);
            }

            return colerrors;
        }

        public List<string> DeleteVertice(DtoVertice dto)
        {
            List<string> colerrors = this.ValidateVertice(dto, false);

            if (colerrors.Count == 0)
            {
                this._Repository.GetVerticeRepository().DeleteVertice(dto.id);
            }

            return colerrors;
        }

        public List<string> ValidateVertice(DtoVertice dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();

            if (isAdd == false && !this._Repository.GetVerticeRepository().ExistVerticeById(dto.id))
                colerrors.Add("El vertice no existe.");

            return colerrors;
        }
    }
}
