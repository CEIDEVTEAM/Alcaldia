using BussinessLogic.Logic;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    public class ZonaController : Controller
    {
        // GET: Zona
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddZona(DtoZona dto)
        {
            LZonaController lgc = new LZonaController();

            List<string> colErrores = lgc.AddZona(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return View();
        }
        [HttpGet]
        public JsonResult PopulatePolygons()
        {
            LZonaController lgc = new LZonaController();
            List<DtoZona> colDto = lgc.GetAllZonas();
            foreach (DtoZona item in colDto)
            {
                item.colVertices.OrderBy(o => o.orden);
            }

            return Json(colDto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            LZonaController lgc = new LZonaController();
            List<DtoZona> colDto = lgc.GetAllZonas();

            return View(colDto);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            LZonaController lgc = new LZonaController();
            DtoZona dto = lgc.GetZonaById(id);
            List<string> colErrores = lgc.DeleteZona(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return RedirectToAction("List");
        }


        public JsonResult ValidateNombre(string nombre)
        {
            bool response = true;
            LZonaController lgc = new LZonaController();
            response = lgc.ExisteZonaByNombre(nombre) ? false : true;


            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}