using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class AdministradorController : Controller
    {
        adminRepositorio adminRepositorio = new adminRepositorio();
        private string nome;
        private int id;
        // GET: Administrador
        public ActionResult IndexADM()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            return View();
        }

        public ActionResult Criar()
        {

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
}
}