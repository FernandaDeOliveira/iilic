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
        private int id;
    
        // GET: Relaciona
        public ActionResult IndexDoença()
        {
            var lista = relacionaRepositorio.getAll();
            return View(lista);
        }

        public ActionResult Criar()
        {
            // int idLogin = (int)TempData.Peek("idLogin");
            return View();
        }


        [HttpPost]
        public ActionResult Criar(Relaciona pRelaciona)
        {
            //int idLogin = (int)TempData.Peek("idLogin");
        

            relacionaRepositorio.criar(pRelaciona);
           
            TempData["idDoenca"] = pRelaciona.Doença.idDoença;
            TempData.Keep("idDoenca");  

            return RedirectToAction("IndexDoença");
        }

        public ActionResult Pergunta()
        {
          //  id = (int)TempData.Peek("idDoenca");
//ViewBag.idDoenca = id;// int idLogin = (int)TempData.Peek("idLogin");
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
        //    id = (int)TempData.Peek("idDoenca");
          //  ViewBag.idDoenca = id;
            return View();
        }

        [HttpPost]
        public ActionResult salvarCaracteristica(Relaciona pRelaciona)
        {
            relacionaRepositorio.criar(pRelaciona);
                return View("IndexDoença");


        }
       
    }
}