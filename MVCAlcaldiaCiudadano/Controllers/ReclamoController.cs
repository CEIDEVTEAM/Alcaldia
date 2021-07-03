using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldiaCiudadano.Controllers
{
    public class ReclamoController : Controller
    {
        // GET: Reclamo
        public ActionResult Add()
        {
            return View();
        }
    }
}