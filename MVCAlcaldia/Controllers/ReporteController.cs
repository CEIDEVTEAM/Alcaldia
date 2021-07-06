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
        [HttpPost]
        public JsonResult PopulateMarkersByCuadrilla(DtoCuadrilla dto)
        {
            LReclamoController lgc = new LReclamoController();
            List<DtoReclamo> colDto = lgc.GetAllReclamosActivosByCuadrilla(dto.id);

            return Json(colDto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ColorReferences()
        {
            return Json(new DtoColorReferences
            {
                GREEN_COLOR_HEX = CMapColor.GREEN_COLOR_HEX,
                YELLOW_COLOR_HEX = CMapColor.YELLOW_COLOR_HEX,
                RED_COLOR_HEX = CMapColor.RED_COLOR_HEX,
                LIMIT_GREEN_HOURS = CMapColor.LIMIT_GREEN_HOURS,
                START_RED_HOURS = CMapColor.START_RED_HOURS
            }, JsonRequestBehavior.AllowGet);
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


        public ActionResult ReporteRecActPorCuadrilla()
        {
            LCuadrillaController lgcc = new LCuadrillaController();
            List<DtoCuadrilla> colDtoZona = lgcc.GetAllCuadrillas();

            List<SelectListItem> cuadrillaSelect = new List<SelectListItem>();

            foreach (DtoCuadrilla item in colDtoZona)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.id.ToString();
                option.Text = item.nombre;
                cuadrillaSelect.Add(option);
            }

            ViewBag.colCuadrillasSelect = cuadrillaSelect;

            return View();
            
        }
        [HttpPost]
        public ActionResult GetReclamosActivosPorCuadrilla(DtoCuadrilla dto)
        {
            LReclamoController lgc = new LReclamoController();

            List<DtoReclamo> colDto = lgc.GetAllReclamosActivosByCuadrilla(dto.id);

            return PartialView("_Listado", colDto);

        }




    }
}