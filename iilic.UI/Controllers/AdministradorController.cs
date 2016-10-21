using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class AdministradorController : Controller
    {
        adminRepositorio adminRepositorio = new adminRepositorio();
        private string nome;
        // GET: Administrador
        [Authorize]///so aparece se estiver logado
        public ActionResult IndexADM()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            return View();
        }

        public ActionResult Criar()
        {
           // int idLogin = (int)TempData.Peek("idLogin");
            return View();
         }


        [HttpPost]
        public ActionResult Criar(Administrador pAdm)
        {
//int idLogin = (int)TempData.Peek("idLogin");
            adminRepositorio.criarADM(pAdm);

            return RedirectToAction("IndexADM");
        }
}
}