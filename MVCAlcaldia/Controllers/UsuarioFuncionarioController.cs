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
    [AuthorizeAttribute]
    public class UsuarioFuncionarioController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddUsuario(DtoUsuario dto)
        {
            LUsuarioController lgc = new LUsuarioController();

            List<string> colErrores = lgc.AddUsuarioFuncionario(dto);

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

            List<string> colErrores = lgc.ModifyUsuarioFuncionario(dto);

            foreach (string error in colErrores)
            {
                ModelState.AddModelError("ErrorGeneral", error);
            }


            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            LUsuarioController lgc = new LUsuarioController();
            List<DtoUsuario> colDto = lgc.GetAllUsers();

            return View(colDto);
        }
    }
}
