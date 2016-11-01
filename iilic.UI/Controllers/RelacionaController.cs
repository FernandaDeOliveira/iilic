using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class RelacionaController : Controller
    {
        relacionaRepositorio relacionaRepositorio = new relacionaRepositorio();
        doencaRepositorio doencaRepositorio = new doencaRepositorio();
        private int id;
        public  int idDoenca2;
    
        // GET: Relaciona
        public ActionResult IndexDoença()
        {
            var lista = doencaRepositorio.getAll();
            return View(lista);
        }

        [HttpPost]
        public ActionResult IndexCaracteristica(int idDoenca)
        {
            var listaCarac = doencaRepositorio.getAllCaracteristica(idDoenca);
            return View(listaCarac);
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
