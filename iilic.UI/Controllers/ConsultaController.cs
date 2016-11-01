using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class ConsultaController : Controller
    {
        consultaRepositorio consultaRepositorio = new consultaRepositorio();
        pacienteRepositorio pacienteRepositorio = new pacienteRepositorio();
        terapeutaRepositorio terapeutaRepositorio = new terapeutaRepositorio();
        // GET: Consulta
        public ActionResult Index()
        {
            //getall
            return View();
        }

        public ActionResult CriarConsulta()
        {
            ViewBag.pacientes = pacienteRepositorio.getAll();
            ViewBag.terapeutas = terapeutaRepositorio.getAll();
            return View();
        }


        [HttpPost]
        public ActionResult CriarConsulta(Consulta pConsulta)
        {
            consultaRepositorio.criar(pConsulta);
            

            return RedirectToAction("Index");
        }
    }
}