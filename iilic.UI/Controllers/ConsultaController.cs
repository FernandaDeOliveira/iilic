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
        public int idConsulta { get; set; }
       

        // GET: Consulta
        public ActionResult Index()
        {
            var consulta = consultaRepositorio.getAll();
            return View(consulta);
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

           idConsulta=consultaRepositorio.criar(pConsulta);
            if (pConsulta.statusPagamento == 1)
            {
                //idConsulta = pConsulta.idConsulta;
               TempData["idConsulta"] = idConsulta;
                TempData.Keep("idConsulta");

                return View("Pagamento");
            }


            return RedirectToAction("Index");
        }

        public ActionResult Pagamento()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Pagamento(float pV, int tV)
        {

           var ident = (int)TempData.Peek("idConsulta");
            if (tV == 1)
            {
                var desc = (pV * 10) / 100;
                float pValor = pV - desc;
                consultaRepositorio.efetuarPagamento(pValor, ident, tV);
                TempData.Remove("idConsulta");
                return View("Pagamento");
            }
            else
                consultaRepositorio.efetuarPagamento(pV, ident, tV);

            return RedirectToAction("Index");
        }
    }
}
