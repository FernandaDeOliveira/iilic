using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iilic.UI.Controllers
{
    public class RelacionaController : Controller
    {
        relacionaRepositorio relacionaRepositorio = new relacionaRepositorio();
        doencaRepositorio doencaRepositorio = new doencaRepositorio();
        pacienteRepositorio pacienteRepo = new pacienteRepositorio();
        caracteristicaRepositorio caracRepo = new caracteristicaRepositorio();
        private int id;
        private string nome; 
        private string nomeP;
    
        // GET: Relaciona
       

        [HttpPost]
        public ActionResult IndexAspectos(int idPaciente)
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            TempData["idPaciente"] = idPaciente;
            TempData.Keep("idPaciente");
            var listaAspectos = pacienteRepo.getAllAspectos(idPaciente);
            //metodo que busca o nomedo paciente pelo id e salva numa viewbag
            nomeP = pacienteRepo.getNomePaciente(idPaciente);
            ViewBag.nomeP = nomeP;
            return View(listaAspectos);
        }


        public ActionResult Editar(int id)
        {
            var caracteristica = caracRepo.getOne(id);
           
            return View(caracteristica);
        }


        [HttpPost]
        public ActionResult Editar(CaracterisTica pCarac)
        {
            caracRepo.editarCaracteristica(pCarac);
            @ViewBag.idPac = TempData.Peek("idPaciente");
            int idPac = ViewBag.idPac;
            //nao deu certo pra retornar pra caracteristicas
            //  return RedirectToAction("IndexAspectos", new { idPac });
            //return RedirectToAction("IndexAspectos", new RouteValueDictionary(
            //   new { controller = Relaciona, action = "Main", Id = Id }));
           // return RedirectToAction( "IndexAspectos","Relaciona", new { idPaciente=idPac });

    
           return RedirectToAction("IndexTerapeuta","Terapeuta");
        }

        public ActionResult Excluir(int idCarac)
        {
            caracRepo.excluir(idCarac);
            return RedirectToAction("IndexTerapeuta", "Terapeuta");
        }

      

      

        public ActionResult Pergunta()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Pergunta(int pId)
        {
            //sim ou não
            if (pId == 1)
            {//puxa view de add caracteristica  
                return RedirectToAction("Aspecto");
            }
            else
                return View("IndexTerapeuta");
        }

        public ActionResult Aspecto()
        {
            ViewBag.codP = TempData.Peek("idPaciente");
            return View();
        }

        [HttpPost]
        public ActionResult Aspecto(int idPaciente)
        {
            TempData["idP"] = idPaciente;
            TempData.Keep("idP");
            return View();
        }

        [HttpPost]
        public ActionResult salvarAspecto(string nomeAspecto)
        {
            var ident = (int)TempData.Peek("idP");
            relacionaRepositorio.criarCaracteristica(nomeAspecto, ident);
            TempData.Remove("idP");
            // return View("Pergunta");
            return RedirectToAction("IndexTerapeuta", "Terapeuta");
        }

    


    }

}
