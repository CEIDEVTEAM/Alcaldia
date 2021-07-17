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
    public class ZonaController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddZona(DtoZona dto)
        {
            LZonaController lgc = new LZonaController();
            List<string> colErrors = lgc.AddZona(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Zona ingresada con éxito";
            }
            else
            {
                string errorShow = "";
                foreach (string item in colErrors)
                    errorShow += "<< " + item + " >>";

                Session[CGlobals.USER_ALERT] = errorShow;
            }


            return View();
        }
        [HttpGet]
        public JsonResult PopulatePolygons()
        {
            LZonaController lgc = new LZonaController();
            List<DtoZona> colDto = lgc.GetAllZonas();

            return Json(colDto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            LZonaController lgc = new LZonaController();
            List<DtoZona> colDto = lgc.GetAllZonas();

            return View(colDto);
        }

        public ActionResult Delete(int id)
        {
            LZonaController lgc = new LZonaController();
            DtoZona dto = lgc.GetZonaById(id);
            List<string> colErrors = lgc.DeleteZona(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Zona dada de baja con éxito";
            }
            else
            {
                string errorShow = "";
                foreach (string item in colErrors)
                    errorShow += "<< " + item + " >>";

                Session[CGlobals.USER_ALERT] = errorShow;
            }

            return RedirectToAction("List");
        }

        #region VALIDATIONS

        public JsonResult ValidateNombre(string nombre)
        {
            bool response = true;
            LZonaController lgc = new LZonaController();
            response = lgc.ExisteZonaByNombre(nombre) ? false : true;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}