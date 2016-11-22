using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace iilic.UI.Controllers
{
    
    public class AdministradorController : Controller
    {
        adminRepositorio adminRepositorio = new adminRepositorio();
        terapeutaRepositorio terapeutaRepositorio = new terapeutaRepositorio();
        consultaRepositorio consultaRepositorio = new consultaRepositorio();
        public string nome;
        private int id;
      
     
        public ActionResult IndexADM()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            DateTime data = DateTime.Now;
            var consultasData= consultaRepositorio.getAllData(data);         
      
               int i = consultasData.Count();
                if (i == 0)
                {
                    return View("Dados");
                }          

            return View(consultasData);
        }



        public ActionResult IndexTer()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            var tera = terapeutaRepositorio.getAll();
                return View(tera);

        }

        [HttpPost]
        public ActionResult Pesquisar(string pesquisa)
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            var tera = terapeutaRepositorio.pesquisar(pesquisa);
            return View(tera);

        }
    }
}