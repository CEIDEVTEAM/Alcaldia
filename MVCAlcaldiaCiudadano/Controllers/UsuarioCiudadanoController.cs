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

    public class UsuarioCiudadanoController : Controller
    {
        public ActionResult Add()
        {

            Session[CGlobals.USER_ACTION] = "A";
            return View();
        }

        public ActionResult AddUsuario(DtoUsuario dto)
        {
            LUsuarioController lgc = new LUsuarioController();

            List<string> colErrors = lgc.AddUsuarioCiudadano(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Usuario registrado con éxito";
                ModelState.Clear();
                Session[CGlobals.USER_ACTION] = null;
            }


            return RedirectToAction("Add");
        }


        [AuthorizeAttribute]
        public ActionResult DeleteUsuario(string nombreDeUsuario)
        {
            LUsuarioController lgc = new LUsuarioController();
            DtoUsuario dto = lgc.GetUserByNombre(nombreDeUsuario);
            List<string> colErrors = lgc.DeleteUsuario(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Usuario dado de baja con éxito";
            }

            return RedirectToAction("List");
        }

        [AuthorizeAttribute]
        public ActionResult Modify()
        {
            string nombreUsuario = Session[CLogin.KEY_SESSION_USERNAME].ToString();
            LUsuarioController lgc = new LUsuarioController();
            DtoUsuario dto = lgc.GetUserByNombre(nombreUsuario);
            Session[CGlobals.USER_ACTION] = "M";

            return View(dto);
        }

        [AuthorizeAttribute]
        [HttpPost]
        public ActionResult ModifyUsuario(DtoUsuario dto)
        {
            LUsuarioController lgc = new LUsuarioController();
            List<string> colErrors = lgc.ModifyUsuarioCiudadano(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Usuario actualizado con éxito";
                Session[CGlobals.USER_ACTION] = null;
            }

            return RedirectToAction("Modify");
        }

        [AuthorizeAttribute]
        public ActionResult ModifyPass(DtoChangePass dto)
        {
            LUsuarioController lgc = new LUsuarioController();
            lgc.ModifyPassword(dto);
            Session[CGlobals.USER_MESSAGE] = "Contraseña actualizada con éxito";

            return RedirectToAction("Modify");
        }

        [AuthorizeAttribute]
        public ActionResult ModifyPassword()
        {
            DtoChangePass dto = new DtoChangePass();
            dto.user = Session[CLogin.KEY_SESSION_USERNAME].ToString();

            return View(dto);
        }

    }
}
