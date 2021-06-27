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
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Home");
            }

            return View();
        }



        [HttpPost]
        public ActionResult Login(DtoLogin dto)
        {
            LUsuarioController lgc = new LUsuarioController();
            if (lgc.ValidateCredentialsFuncionario(dto))
            {
                FormsAuthentication.SetAuthCookie(dto.user, false);
                Session[CLogin.KEY_SESSION_USERNAME] = dto.user;

                return Redirect("/Home");
            }


            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();

            return Redirect("/Home");
        }

    }
}