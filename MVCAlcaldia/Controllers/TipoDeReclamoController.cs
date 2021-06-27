using BussinessLogic.Logic;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    public class TipoDeReclamoController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            
            List<string> colErrores = lgc.AddTipoDeReclamo(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return View("Add");
        }



        public ActionResult DeleteTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();

            List<string> colErrores = lgc.DeleteTipoDeReclamo(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return View("List");
        }


        public ActionResult Modify(string nombre)
        {

            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            DtoTipoDeReclamo dto = lgc.GetTipoDeReclamoByName(nombre);


            return View(dto);
        }

        [HttpPost]
        public ActionResult ModifyTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();

            List<string> colErrors = lgc.ModifyTipoDeReclamo(dto);

            foreach (string error in colErrors)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<DtoTipoDeReclamo> colDto = lgc.GetAllTipoDeReclamo();

            return View(colDto);
        }

    }
}