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
        private string nome;
        private int id;
      
     
        public ActionResult IndexADM()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            DateTime data = DateTime.Now;
            var consultasData= consultaRepositorio.getAllData(data);
          
         //   for (int i = 0; i < consultasData.Count(); i++)
          //  {
               int i = consultasData.Count();
                if (i == 0)
                {//carregar aqui o get all de todas
                    return View("Dados");
                }
              
       //     }
           

            return View(consultasData);
            

        }



        public ActionResult IndexTer()
        {
     
                var tera = terapeutaRepositorio.getAll();
                return View(tera);

        }


        public ActionResult Pesquisar(string pesquisa)
        {

            var tera = terapeutaRepositorio.pesquisar(pesquisa);
            return View(tera);

        }
    }
}