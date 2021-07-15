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
    public class CuadrillaController : Controller
    {
        public ActionResult Add()
        {
            LZonaController zonaController = new LZonaController();
            List<DtoZona> colDtoZona = zonaController.GetAllZonas();
          
            List<SelectListItem> colZonasSelect = new List<SelectListItem>();

            foreach (DtoZona item in colDtoZona)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.id.ToString();
                option.Text = item.nombre;
                colZonasSelect.Add(option);
            }

            ViewBag.colZonasSelect = colZonasSelect;

            return View();
        }

        [HttpPost]
        public ActionResult AddCuadrilla(DtoCuadrilla dto)
        {
            LCuadrillaController lgc = new LCuadrillaController();

            List<string> colErrors = new List<string>();
            colErrors = lgc.AddCuadrilla(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Cuadrilla ingresada con éxito";
                ModelState.Clear();
                Session[CGlobals.USER_ACTION] = null;
            }

            return RedirectToAction("Add");
        }

        public ActionResult List()
        {
            LCuadrillaController lgc = new LCuadrillaController();
            List<DtoCuadrilla> colDto = lgc.GetAllCuadrillas();

            return View(colDto);
        }

        public ActionResult Modify(int? id)
        {
            LZonaController zonaController = new LZonaController();
            List<DtoZona> colDtoZona = zonaController.GetAllZonas();

            List<SelectListItem> colZonasSelect = new List<SelectListItem>();

            foreach (DtoZona item in colDtoZona)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.id.ToString();
                option.Text = item.nombre;
                colZonasSelect.Add(option);
            }

            ViewBag.colZonasSelect = colZonasSelect;

            LCuadrillaController lgc = new LCuadrillaController();
            DtoCuadrilla dto = lgc.GetCuadrillaById(id ?? 0);


            return View(dto);
        }

        [HttpPost]
        public ActionResult ModifyCuadrilla(DtoCuadrilla dto)
        {
            LCuadrillaController lgc = new LCuadrillaController();
            List<string> colErrors = lgc.ModifyCuadrilla(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Cuadrilla actualizada con éxito";
                Session[CGlobals.USER_ACTION] = null;
            }

            return RedirectToAction("Modify");
        }

        public ActionResult Delete(int id)
        {
            LCuadrillaController lgc = new LCuadrillaController();
            DtoCuadrilla dto = lgc.GetCuadrillaById(id);
            List<string> colErrors = lgc.DeleteCuadrilla(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Cuadrilla dada de baja con éxito";
            }
            else
            {
                Session[CGlobals.USER_MESSAGE] = "Cuadrilla NO se ha dado de baja, tiene reclamos activos";
            }

            return RedirectToAction("List");
        }

        #region VALIDATIONS
        public JsonResult ValidateNombre(string nombre, int? id)
        {
            bool response = true;
            LCuadrillaController lgc = new LCuadrillaController();

            if (Session[CGlobals.USER_ACTION].ToString() == "A")
                response = lgc.ExistCuadrillaByName(nombre) ? false : true;

            else if (Session[CGlobals.USER_ACTION].ToString() == "M")
            {
                response = lgc.ExistCuadrillaByNameAndId(nombre, id ?? 0) ? true : false;
                if(!response)
                    response = lgc.ExistCuadrillaByName(nombre) ? false : true;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }



        #endregion
    }
}