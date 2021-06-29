﻿using BussinessLogic.Logic;
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

            foreach (string error in colErrors)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }

            return View("Add");
        }

        public ActionResult List()
        {
            LCuadrillaController lgc = new LCuadrillaController();
            List<DtoCuadrilla> colDto = lgc.GetAllCuadrillas();

            return View(colDto);
        }

        public ActionResult Modify(int id)
        {

            LCuadrillaController lgc = new LCuadrillaController();
            DtoCuadrilla dto = lgc.GetCuadrillaById(id);

            return View(dto);
        }

        [HttpPost]
        public ActionResult ModifyCuadrilla(DtoCuadrilla dto)
        {
            LCuadrillaController lgc = new LCuadrillaController();

            List<string> colErrors = lgc.ModifyCuadrilla(dto);

            foreach (string error in colErrors)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return RedirectToAction("List");
        }


    }
}