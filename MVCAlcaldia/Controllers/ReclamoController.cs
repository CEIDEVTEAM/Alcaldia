using BussinessLogic.Logic;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    [AuthorizeAttribute]
    public class ReclamoController : Controller
    {
        public ActionResult List()
        {          

            return View();
        }

        [HttpPost]
        public ActionResult GetReclamosPorFechaYestado(DtoReclamo dto)
        {
            LReclamoController lgc = new LReclamoController();

            List<DtoReclamo> colDto = lgc.GetAllReclamosByFechaYestado(dto);

            return PartialView("_D_List", colDto);
        }


        public ActionResult Modify(int id)
        {
            
            LReclamoController lgc = new LReclamoController();
            DtoReclamo dto = lgc.GetReclamoById(id);

            return View(dto);
        }

        [HttpPost]
        public ActionResult ModifyReclamo(DtoReclamo dto)
        {
            LReclamoController lgc = new LReclamoController();

            List<string> colErrors = lgc.ModifyReclamo(dto);

            return RedirectToAction("List");
        }
    }
}