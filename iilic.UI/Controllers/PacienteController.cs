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
        public string nome;
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

        [HttpPost]
        public ActionResult Pesquisar(string pesquisa)
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            var pac = pacienteRepositorio.pesquisar(pesquisa);
            return View(pac);

        }

        public ActionResult Editar(int id)
        {
            var paciente = pacienteRepositorio.getOne(id);

            return View(paciente);
        }


        [HttpPost]
        public ActionResult Editar(Paciente pPac)
        {
            pacienteRepositorio.editarPaciente(pPac);
            return RedirectToAction("Index");
        }
    }
}