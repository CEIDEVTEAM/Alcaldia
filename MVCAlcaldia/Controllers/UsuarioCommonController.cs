using BussinessLogic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    public class UsuarioCommonController : Controller
    {
        #region VALIDATIONS

        public JsonResult ValidateUserName(string nombreDeUsuario)
        {
            bool response = true;
            LUsuarioController lgc = new LUsuarioController();
            response = lgc.ExistUsuarioByNombre(nombreDeUsuario) ? false : true;

            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ValidatePasswordNewUser(string contrasenia, string repContrasenia)
        {
            bool response = false;
            if (contrasenia == repContrasenia)
                response = true;

            return Json(response, JsonRequestBehavior.AllowGet);
        }
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