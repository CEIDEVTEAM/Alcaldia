using BussinessLogic.Logic;
using CommonSolution.DTOs;
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
    }
}