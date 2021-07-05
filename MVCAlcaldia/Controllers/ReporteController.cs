using BussinessLogic.Logic;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult VisorReclamosNoResueltos()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PopulateMarkers()
        {
            LReclamoController lgc = new LReclamoController();
            List<DtoReclamo> colDto = lgc.GetReclamoWithRetraso();
            
            return Json(colDto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MapaTermico()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PopulateLatLng()
        {
            LReclamoController lgc = new LReclamoController();
            List<DtoVertice> colDto = lgc.GetAllUbicacionesReclamos();

            return Json(colDto, JsonRequestBehavior.AllowGet);
        }
    }
}