using BussinessLogic.Logic;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCAlcaldia.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Home");
            }

            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(DtoLogin dto, string returnUrl)
        {
            LUsuarioController lgc = new LUsuarioController();
            if (lgc.ValidateCredentialsFuncionario(dto))
            {
                FormsAuthentication.SetAuthCookie(dto.user, false);
                Session[CLogin.KEY_SESSION_USERNAME] = dto.user;
                Session[CGlobals.USER_MESSAGE] = "Bienvenido " + dto.user;

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect("/Home");

                }
                return Redirect(returnUrl);

            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();

            return Redirect("/Home");
        }

        #region VALIDATIONS

        public JsonResult ValidateCredentials(string user, string pass)
        {
            bool response = true;
            LUsuarioController lgc = new LUsuarioController();
            DtoLogin dtoLogin = new DtoLogin();
            dtoLogin.user = user;
            dtoLogin.pass = pass;
            dtoLogin.tipoDeUsuario = CUsuario.USER_FUNCIONARIO;
            response = lgc.ExistCredentialsByUserAndPass(dtoLogin) ? true : false;

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}