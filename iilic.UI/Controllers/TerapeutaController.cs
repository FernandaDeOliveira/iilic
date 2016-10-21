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

        /// <summary> Possivel resposta
        /// http://www.100loop.com/asp-net/seguranca-de-aplicacoes-mvc-4-com-atributos-de-authorize/
        /// http://devbrasil.net/profiles/blog/show?id=2307362%3ABlogPost%3A158798&commentId=2307362%3AComment%3A290013&xg_source=activity
        /// </summary>
        /// <returns></returns>

        
        public ActionResult IndexTer()
        {
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
        public ActionResult CriarTerapeuta(Terapeuta pT)
        {
            terapeutaRepositorio.criar(pT);
            return RedirectToAction("IndexTer");
        }
    }
}