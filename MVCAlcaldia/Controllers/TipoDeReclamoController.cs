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

            return View();
        }

        public ActionResult AddTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<string> colErrors = lgc.AddTipoDeReclamo(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Tipo de reclamo agregado con éxito";
                ModelState.Clear();
            }

            return View("Add");
        }



        public ActionResult DeleteTipoDeReclamo(DtoTipoDeReclamo dto)
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<string> colErrors = lgc.DeleteTipoDeReclamo(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Tipo de reclamo dado de baja";
                ModelState.Clear();
            }

            return View("List");
        }


        public ActionResult Modify(string nombre)
        {
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
                Session[CGlobals.USER_MESSAGE] = "Tipo de reclamo actualizado con éxito";
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

        public JsonResult ValidateNombre(string nombre, string task)
        {
            bool response = false;
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();

            if (task == CGlobals.USER_ACTION_ADD)
                response = lgc.ExistTipoDeReclamoByNombre(nombre) ? false : true;

            else if (task == CGlobals.USER_ACTION_MOD)
                response = lgc.ExistTipoDeReclamoByNombre(nombre) ? true : false;


            return Json(response, JsonRequestBehavior.AllowGet);
        }



        #endregion 



    }
}