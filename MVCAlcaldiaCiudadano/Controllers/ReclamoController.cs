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
            //dto.idCiudadano = Session[CLogin.KEY_SESSION_USERNAME].ToString();
            dto.fechaYhora = DateTime.Now;
            dto.estado = EnumEstado.PENDIENTE;
            //dto.idCuadrilla = funcion
            LReclamoController lgc = new LReclamoController();
            colErrors = lgc.AddReclamo(dto);
            //funcion popUp de operación exitosa

            return View();
        }
    }
}