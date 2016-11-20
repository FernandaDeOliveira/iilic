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
        public  int idDoenca2;
        private string nomeP;
    
        // GET: Relaciona
        //esse aqui é o indexterapeuta 
        //OK
        public ActionResult IndexDoença()
        {
            var lista = doencaRepositorio.getAll();
            return View(lista);
        }

        [HttpPost]
        //index dos aspectos, passa o id do paciente
        public ActionResult IndexCaracteristica(int idDoenca)
        {
            var listaCarac = doencaRepositorio.getAllCaracteristica(idDoenca);
            return View(listaCarac);
        }

        [HttpPost]
        public ActionResult IndexAspectos(int idPaciente)
        {
            TempData["idPaciente"] = idPaciente;
            TempData.Keep("idPaciente");
            var listaAspectos = pacienteRepo.getAllAspectos(idPaciente);
            //metodo que busca o nomedo paciente pelo id e salva numa viewbag
            nomeP = pacienteRepo.getNomePaciente(idPaciente);
            ViewBag.nomeP = nomeP;
            return View(listaAspectos);
        }

        public ActionResult Editar(int idCarac)
        {
            var caracteristica = caracRepo.getOne(idCarac);
           
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

        public ActionResult Criar()
        {
          
            return View();
        }


        [HttpPost]
        public ActionResult Criar(Relaciona pRelaciona)
        {                 
            relacionaRepositorio.criar(pRelaciona);
           
            TempData["idDoenca"] = pRelaciona.Doenca.idDoenca;
            TempData.Keep("idDoenca");  

            return RedirectToAction("Pergunta");
            }

        public ActionResult Pergunta()
        {   
            return View();
        }


        [HttpPost]
        public ActionResult Pergunta(int pId)
        {
            
            if (pId == 1)
            {//puxa view de add caracteristica  
                return RedirectToAction("Caracteristica");
            }
            else
                return View("IndexDoença");

          
        }


        public ActionResult Caracteristica()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Caracteristica(Doenca Doenca)
        {
            TempData["idD"] = Doenca.idDoenca;
            TempData.Keep("idD");
            return View();
        }



        [HttpPost]
        public ActionResult salvarCaracteristica(string nDoenca)
        {
            var ident = (int)TempData.Peek("idD");
            relacionaRepositorio.criarCaracteristica(nDoenca, ident);
            TempData.Remove("idD");
            return View("Pergunta");
        }


    }

}
