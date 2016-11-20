using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class TerapeutaController : Controller
    {
        AdministradorController adm = new AdministradorController();
        terapeutaRepositorio terapeutaRepositorio = new terapeutaRepositorio();
        loginRepositorio loginrepo = new loginRepositorio();
        consultaRepositorio consultaRepo = new consultaRepositorio();
        private string nome { get; set; }
        private int id;
        private int numeroMed;
        // GET: Terapeuta
        
        public ActionResult IndexTerapeuta()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            //chamar um metodo q pega o login e puxa o id pra ca //salva o id numavariavel            
            
            numeroMed = loginrepo.buscaNumMed(nome);
            //passa pra outro metodo q pega as consultas naquele id
            var consultas=consultaRepo.getAllTerapeuta(numeroMed);
       

            return View(consultas);
        }
/// <summary>
/// é a de antes
/// </summary>
/// <returns></returns>
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
    }
}