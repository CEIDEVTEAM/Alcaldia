﻿using BussinessLogic.Logic;
using CommonSolution.Constants;
using CommonSolution.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAlcaldia.Controllers
{
    [AuthorizeAttribute]
    public class UsuarioCommonController : Controller
    {
        #region VALIDATIONS

        public JsonResult ValidateUserName(string nombreDeUsuario, string task)
        {
            bool response = false;
            LUsuarioController lgc = new LUsuarioController();

            if (task == CGlobals.USER_ACTION_ADD)
                response = lgc.ExistUsuarioByNombre(nombreDeUsuario) ? false : true;

            else if (task == CGlobals.USER_ACTION_MOD)
                response = lgc.ExistUsuarioByNombre(nombreDeUsuario) ? true : false;

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