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
        // GET: Administrador
        public ActionResult IndexADM()
        {
            return View();
        }

        public ActionResult Criar()
        {             
            return View();
         }


        [HttpPost]
        public ActionResult Criar(Administrador pAdm)
        {
            adminRepositorio.criarADM(pAdm);

            return RedirectToAction("IndexADM");
        }
}
}