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
            LCuadrillaController lgcc = new LCuadrillaController();
            dto.idCiudadano = Session[CLogin.KEY_SESSION_USERNAME].ToString();
            dto.fechaYhora = DateTime.Now;
            dto.estado = EnumEstado.PENDIENTE;
            LReclamoController lgc = new LReclamoController();
            lgc.CuadrillaForReclamo(dto);
            colErrors = lgc.AddReclamo(dto);
            //funcion popUp de operación exitosa

            return View();
        }

        public ActionResult List()
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

        public ActionResult Delete(int id)
        {
            LReclamoController lgc = new LReclamoController();
            DtoReclamo dto = lgc.GetReclamoById(id);
            
            List<string> colErrores = lgc.DeleteReclamo(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return RedirectToAction("List");
        }

        //DeleteReclamo
    }
}