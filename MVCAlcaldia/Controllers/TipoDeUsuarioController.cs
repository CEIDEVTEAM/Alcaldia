using BussinessLogic.Logic;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    public class TipoDeUsuarioController : Controller
    {
        public ActionResult Agregar()
        {

            return View();
        }

        /// <summary>
        /// PRUEBA
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>


        public ActionResult AgregarTipo(DtoTipoUsuario dto)
        {
            LTipoDeUsuarioController tipoController = new LTipoDeUsuarioController();
            List<string> colErrores = tipoController.AddTipoDeUsuario(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }

            return View("Agregar");
        }

    }
}
