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

    public class UsuarioFuncionarioController : Controller
    {
        public ActionResult Add()
        {

            return View();
        }

        public ActionResult AddUsuario(DtoUsuario dto)
        {
            LUsuarioController lgc = new LUsuarioController();

            List<string> colErrors = lgc.AddUsuarioFuncionario(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Usuario registrado con éxito";
                ModelState.Clear();

            }

            return View("Add");
        }

        
        public ActionResult DeleteUsuario(string nombreDeUsuario)
        {
            LUsuarioController lgc = new LUsuarioController();
            DtoUsuario dto = lgc.GetUserByNombre(nombreDeUsuario);
            List<string> colErrors = lgc.DeleteUsuario(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Usuario dado de baja con éxito";
            }

            return RedirectToAction("ListFuncionario");
        }


        public ActionResult Modify()
        {
            if (Session[CLogin.KEY_SESSION_USERNAME] != null)
            {
                string nombreUsuario = Session[CLogin.KEY_SESSION_USERNAME].ToString();
                LUsuarioController lgc = new LUsuarioController();
                DtoUsuario dto = lgc.GetUserByNombre(nombreUsuario);
                return View(dto);
            }

            Session[CGlobals.USER_ALERT] = "La sesión expiró, vuelvea a loguearse.";
            return RedirectToAction("Login", "Login");

        }

        [HttpPost]
        public ActionResult ModifyUsuario(DtoUsuario dto)
        {
            LUsuarioController lgc = new LUsuarioController();
            List<string> colErrors = lgc.ModifyUsuarioFuncionario(dto);

            if (colErrors.Count == 0)
            {
                Session[CGlobals.USER_MESSAGE] = "Usuario actualizado con éxito";
            }

            return RedirectToAction("Modify");
        }

        public ActionResult ListFuncionario()
        {
            LUsuarioController lgc = new LUsuarioController();
            List<DtoUsuario> colDto = lgc.GetAllUsersFuncionario();

            return View(colDto);
        }
        public ActionResult ListCiudadano()
        {
            LUsuarioController lgc = new LUsuarioController();
            List<DtoUsuario> colDto = lgc.GetAllUsersCiudadano();

            return View(colDto);
        }

        public ActionResult ModifyPass(DtoChangePass dto)
        {
            LUsuarioController lgc = new LUsuarioController();
            lgc.ModifyPassword(dto);
            Session[CGlobals.USER_MESSAGE] = "Contraseña actualizada con éxito";

            return RedirectToAction("Modify");
        }

        public ActionResult ModifyPassword()
        {
            if (Session[CLogin.KEY_SESSION_USERNAME] != null)
            {
                DtoChangePass dto = new DtoChangePass();
                dto.user = Session[CLogin.KEY_SESSION_USERNAME].ToString();
                return View(dto);
            }

            Session[CGlobals.USER_ALERT] = "La sesión expiró, vuelvea a loguearse.";
            return RedirectToAction("Login", "Login");
        }


    }
}
