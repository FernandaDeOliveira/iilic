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
        consultaRepositorio consulta = new consultaRepositorio();
        private string nome;
        private int id;
        // GET: Administrador

    //    public ActionResult LogOut()
    //    {
//FormsAuthentication.SignOut();
   //         Session.Abandon(); // it will clear the session at the end of request
//return RedirectToAction("Index", "Login");
//}


        public ActionResult IndexADM()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            DateTime data = DateTime.Now;
            var consultasData= consulta.getAllData(data);
         
            return View(consultasData);
        }

        public ActionResult Criar()
        {
            //pegar o id aqui e testar se eh null
            if (id != null)
            {
                //vai carregar um getOne pra exibir os dados de quem ta logado
                //vai armazenar numa 
                return View("Dados");

            }
            else
            {
                id = (int)TempData.Peek("valorLog");
                ViewBag.idLogin = id;
            }
                return View();
            
           
         }


        [HttpPost]
        public ActionResult Criar(Administrador pAdm)
        {
            
            adminRepositorio.criarADM(pAdm);

            return RedirectToAction("IndexADM");
        }


        public ActionResult CriarTerapeuta()
        {

            
            return View();


        }


        [HttpPost]
        public ActionResult CriarTerapeuta(Terapeuta pTerapeuta)
        {

            terapeutaRepositorio.criarTer(pTerapeuta);

            return RedirectToAction("IndexTer");
        }

        public ActionResult IndexTer()
        {
     
                var tera = terapeutaRepositorio.getAll();
                return View(tera);

        }
    }
}