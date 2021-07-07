using BussinessLogic.Logic;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldiaCiudadano.Controllers
{
    [AuthorizeAttribute]
    public class UsuarioCiudadanoController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddUsuario(DtoUsuario dto)
        {
            LUsuarioController lgc = new LUsuarioController();

            List<string> colErrores = lgc.AddUsuarioCiudadano(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return View("Add");
        }



        public ActionResult DeleteUsuario(string nombreDeUsuario)
        {
            LUsuarioController lgc = new LUsuarioController();
            DtoUsuario dto = lgc.GetUserByNombre(nombreDeUsuario);
            List<string> colErrores = lgc.DeleteUsuario(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }

            return RedirectToAction("List");
        }


        public ActionResult Modify()
        {
            string nombreUsuario = Session[CLogin.KEY_SESSION_USERNAME].ToString();
            LUsuarioController lgc = new LUsuarioController();
            DtoUsuario dto = lgc.GetUserByNombre(nombreUsuario);


            return View(dto);
        }

        [HttpPost]
        public ActionResult ModifyUsuario(DtoUsuario dto)
        {
            LUsuarioController lgc = new LUsuarioController();

            List<string> colErrores = lgc.ModifyUsuarioCiudadano(dto);


            return RedirectToAction("Modify");
        }




        public ActionResult ModifyPass(DtoChangePass dto)
        {
            LUsuarioController lgc = new LUsuarioController();
            //List<string> colErrores = lgc.ModifyPassword(dto);

            return RedirectToAction("Modify, UsuarioCiudadano");
        }

        public ActionResult ModifyPassword()
        {
            DtoChangePass dto = new DtoChangePass();
            dto.user = Session[CLogin.KEY_SESSION_USERNAME].ToString();

            return View(dto);
        }


        #region VALIDATIONS

        public JsonResult ValidateNewPassword(string newPass, string repNewPass)
        {
            bool response = false;
            if (newPass == repNewPass)
                response = true;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        #endregion



    }
}
