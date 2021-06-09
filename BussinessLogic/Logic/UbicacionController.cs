using CommonSolution.DTOs;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Logic
{
    public class UbicacionController
    {
        private Repository _Repository;

        public UbicacionController()
        {
            this._Repository = new Repository();
        }

        //CORROBORAR SI VAMOS A CAMBIAR LA PK DE LA TABLA UBICACION

        public List<string> ValidateUbicacion(DtoUbicacion dto, bool isAdd)
        {
            List<string> colerrors = new List<string>();



            return colerrors;
        }


    }
}
