using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class TerapeutaController : Controller
    {
        AdministradorController adm = new AdministradorController();
        terapeutaRepositorio terapeutaRepositorio = new terapeutaRepositorio();
        private string nome { get; set; }
        private int id;
        // GET: Terapeuta
        
        public ActionResult IndexTerapeuta()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            id = (int)TempData.Peek("valorLog");
            ViewBag.id = id;
            if (ViewBag.id==1)
            {
                var tera = terapeutaRepositorio.getAll();
                return View(tera);
            }
            else
            {

            }
            return View("Index2");
        }

        public ActionResult CriarTerapeuta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarTerapeuta(Terapeuta pTerapeuta)
        {
            terapeutaRepositorio.criarTer(pTerapeuta);
            return RedirectToAction("IndexTer");
        }
    }
}