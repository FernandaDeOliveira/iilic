using iilic.Core;
using iilic.Repositorio;
using Rotativa;
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
        sessaoRepositorio sessaoRepositorio = new sessaoRepositorio();
        mesRepositorio mesRepositorio = new mesRepositorio();
        pagamentoRepositorio pagamentoRepositorio = new pagamentoRepositorio();
        public int idConsulta { get; set; }
        public string nome;

        public ActionResult Index()
        {//EXIBE AS Q ESTAO EM ABERTO
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            var consulta = consultaRepositorio.getAllAbertas();
            // if(consulta)
            return View(consulta);
        }
        //EXIBE AS QUE ESTÃO PAGAS
        public ActionResult IndexConsultasPagas()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            var consulta = consultaRepositorio.getAllPagas();
           
            return View(consulta);
        }

        public ActionResult CriarConsulta()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
           
                ViewBag.pacientes = pacienteRepositorio.getAll();
            ViewBag.terapeutas = terapeutaRepositorio.getAll();
            return View();
        }


        [HttpPost]
        public ActionResult CriarConsulta(Consulta pConsulta)
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;

               var r = consultaRepositorio.getConsultas(pConsulta);
            // var r = consultaRepositorio.
            if (r == true)
            {
                ViewBag.consulta = "Já existe uma consulta com esses dados";

                ViewBag.pacientes = pacienteRepositorio.getAll();
                ViewBag.terapeutas = terapeutaRepositorio.getAll();
                return View("CriarConsulta");
            }
            else
            {
                idConsulta = consultaRepositorio.criar(pConsulta);
            }
            //se o status é igual a sim
            if (pConsulta.statusPagamento == 1)
            {
                //idConsulta = pConsulta.idConsulta;
                TempData["idConsulta"] = idConsulta;
                TempData.Keep("idConsulta");

                return View("Pagamento");
            }


            return RedirectToAction("Index");
        }


        public ActionResult Editar(int id)
        {
            var consulta = consultaRepositorio.getEditar(id);

            return View(consulta);
        }

        [HttpPost]
        public ActionResult Editar(Consulta pConsulta)
        {

            //    AlunoRepository.Edit(pAluno);
            return RedirectToAction("Index");
        }
        // EFETUA PAGAMNETO ASSIM Q MARCA CONSULTA  
        public ActionResult PagamentoBotao(int id)
        {
            TempData["idConsulta"] = id;
            TempData.Keep("idConsulta");

            return View("Pagamento");
        }

        public ActionResult Pagamento()
        {
            //var ident = (int)TempData.Peek("idConsulta");

            return View();
        }


        [HttpPost]
        public ActionResult Pagamento(float pV, int tV)
        {

            var ident = (int)TempData.Peek("idConsulta");
            if (tV == 1)
            {
                var desc = (pV * 20) / 100;
                float pValor = pV - desc;
                consultaRepositorio.efetuarPagamento(pValor, tV, ident);
                mesRepositorio.criarFinanMes(pValor);
                consultaRepositorio.mudaStatusPagamento(ident);
                TempData.Remove("idConsulta");
                return View("Index");
            }
            else
                consultaRepositorio.efetuarPagamento(pV, ident, tV);
            sessaoRepositorio.criarFinanSessao(pV);
            consultaRepositorio.mudaStatusPagamento(ident);
            TempData.Remove("idConsulta");
            return RedirectToAction("Index");
        }

      

    }
    
}
