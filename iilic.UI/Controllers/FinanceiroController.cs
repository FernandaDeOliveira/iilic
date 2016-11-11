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
        // GET: Financeiro
        public ActionResult Geral()
        {
            ViewBag.mes = mesRepositorio.totalMes();
            return View();
        }


      
    }
}