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
        terapeutaRepositorio terapeutaRepositorio = new terapeutaRepositorio();
        // GET: Terapeuta
        public ActionResult IndexTer()
        {
            var tera = terapeutaRepositorio.getAll();
            return View(tera);
        }
    }
}