using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class PacienteController : Controller
    {
        pacienteRepositorio pacienteRepositorio = new pacienteRepositorio();
        // GET: Paciente
        public ActionResult Index()
        {
            var pac = pacienteRepositorio.getAll();
            return View(pac);
        }

        public ActionResult CriarPaciente()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CriarPaciente(Paciente pPaciente)
        {

            pacienteRepositorio.criar(pPaciente);

            return RedirectToAction("Index");
        }

    }
}