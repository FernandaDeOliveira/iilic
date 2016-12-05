using iilic.Core;
using iilic.Repositorio;
using Rotativa;
using Rotativa.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class FinanceiroController : Controller
    {
        mesRepositorio mesRepositorio = new mesRepositorio();
        sessaoRepositorio sessaoRepositorio = new sessaoRepositorio();
        private string nome;
        // GET: Financeiro
        public ActionResult Geral()
        {
            nome = (string)TempData.Peek("login");
            ViewBag.nome = nome;
            ViewBag.mes = mesRepositorio.totalMes();
            ViewBag.sessao = sessaoRepositorio.totalSessao();
            return View();
        }


      
    }
}