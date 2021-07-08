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
    public class TipoDeReclamoController : Controller
    {
        public ActionResult Add()
        {

            Session[CGlobals.USER_ACTION] = "A";
            return View();
        }

        public ActionResult AddTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<string> colErrors = lgc.AddTipoDeReclamo(dto);

            if (colErrors.Count == 0)
            {
                ViewBag.Message = "Tipo de reclamo agregado con éxito";
                ModelState.Clear();
                Session[CGlobals.USER_ACTION] = "";
            }

            return View("Add");
        }



        public ActionResult DeleteTipoDeReclamo(DtoTipoDeReclamo dto)
        {

            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<string> colErrors = lgc.DeleteTipoDeReclamo(dto);

            if (colErrors.Count == 0)
            {
                ViewBag.Message = "Tipo de reclamo dado de baja";
                ModelState.Clear();
            }

            return View("List");
        }


        public ActionResult Modify(string nombre)
        {

            Session[CGlobals.USER_ACTION] = "M";
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            DtoTipoDeReclamo dto = lgc.GetTipoDeReclamoByName(nombre);

            return View(dto);
        }

 
        public ActionResult ModifyTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<string> colErrors = lgc.ModifyTipoDeReclamo(dto);

            if (colErrors.Count == 0)
            {
                ViewBag.Message = "Tipo de reclamo actualizado con éxito";
                Session[CGlobals.USER_ACTION] = "";
            }

            return View("Modify");
        }

        public ActionResult List()
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<DtoTipoDeReclamo> colDto = lgc.GetAllTipoDeReclamo();

            return View(colDto);
        }

        #region VALIDATIONS

        public JsonResult ValidateNombre(string nombre)
        {
            bool response = true;
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();

            if (Session[CGlobals.USER_ACTION].ToString() == "A")
                response = lgc.ExistTipoDeReclamoByNombre(nombre) ? false : true;

            else if (Session[CGlobals.USER_ACTION].ToString() == "M")
                response = lgc.ExistTipoDeReclamoByNombre(nombre) ? true : false;


            return Json(response, JsonRequestBehavior.AllowGet);
        }



        #endregion 



    }
}