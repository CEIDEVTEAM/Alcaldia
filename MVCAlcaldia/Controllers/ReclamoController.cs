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
    public class ReclamoController : Controller
    {
        // GET: Reclamo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            LReclamoController lgc = new LReclamoController();
            List<DtoReclamo> colDto = lgc.GetAllReclamos();

            return View(colDto);
        }
    }
}