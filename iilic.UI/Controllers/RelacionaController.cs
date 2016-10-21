using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class RelacionaController : Controller
    {
        relacionaRepositorio relacionaRepositorio = new relacionaRepositorio();
        // GET: Relaciona
        public ActionResult IndexDoença()
        {
            return View();
        }

        public ActionResult Criar()
        {
            // int idLogin = (int)TempData.Peek("idLogin");
            return View();
        }


        [HttpPost]
        public ActionResult Criar(Relaciona pRelaciona)
        {
            //int idLogin = (int)TempData.Peek("idLogin");
            relacionaRepositorio.criar(pRelaciona);

            return RedirectToAction("IndexDoença");
        }
    }
}