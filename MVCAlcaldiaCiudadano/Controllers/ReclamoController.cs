using BussinessLogic.Logic;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using CommonSolution.ENUMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldiaCiudadano.Controllers
{
    [AuthorizeAttribute]
    public class ReclamoController : Controller
    {
        public ActionResult Add()
        {
            LTipoDeReclamoController lgc = new LTipoDeReclamoController();
            List<DtoTipoDeReclamo> colDtoTipoDeReclamo = lgc.GetAllTipoDeReclamo();

            List<SelectListItem> colTipoDeReclamoSelect = new List<SelectListItem>();

            foreach (DtoTipoDeReclamo item in colDtoTipoDeReclamo)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.nombre;
                option.Text = item.nombre;
                colTipoDeReclamoSelect.Add(option);
            }

            ViewBag.colTipoDeReclamoSelect = colTipoDeReclamoSelect;
            return View();
        }


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

        [HttpPost]
        public ActionResult AddReclamo(DtoReclamo dto)
        {
            List<string> colErrors = new List<string>();
            dto.idCiudadano = Session[CLogin.KEY_SESSION_USERNAME].ToString();
            dto.fechaYhora = DateTime.Now;
            dto.estado = EnumEstado.PENDIENTE;
            LReclamoController lgc = new LReclamoController();
            colErrors = lgc.AddReclamo(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Reclamo registrado con éxito";
                ModelState.Clear();

            }

            return View();
        }

        public ActionResult List()
        {
            LReclamoController lgc = new LReclamoController();
            string user = Session[CLogin.KEY_SESSION_USERNAME].ToString();
            List<DtoReclamo> colDto = lgc.GetAllReclamosByUser(user);

            return View(colDto);
        }
        public ActionResult Grid()
        {
            LReclamoController lgc = new LReclamoController();
            string user = Session[CLogin.KEY_SESSION_USERNAME].ToString();
            List<DtoReclamo> colDto = lgc.GetAllReclamosByUser(user);

            return View(colDto);
        }

        public ActionResult Details(int id)
        {
            LLogReclamoController lgc = new LLogReclamoController();
            
            List<DtoLogReclamo> colDto = lgc.GetLogReclamoById(id);

            return View(colDto);
        }
        [HttpPost]
        public JsonResult Delete(DtoReclamo dto)
        {
            LReclamoController lgc = new LReclamoController();
            DtoReclamo DtoRec = lgc.GetReclamoById(dto.id);
            
            List<string> colErrores = lgc.DeleteReclamo(DtoRec);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return Json(JsonRequestBehavior.AllowGet);
        }

        //DeleteReclamo
    }
}