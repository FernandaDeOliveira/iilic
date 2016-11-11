using iilic.Repositorio;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iilic.UI.Controllers
{
    public class PDFController : Controller
    {
        consultaRepositorio consultaRepositorio = new consultaRepositorio();
        pagamentoRepositorio pagamentoRepositorio = new pagamentoRepositorio();
        // GET: PDF
      
        public ActionResult getPDF(int id)
        {

            var consulta = consultaRepositorio.getOne(id);
            ViewBag.valor = pagamentoRepositorio.getOne(id);
            //   ViewData["valor"] = pagamentoRepositorio.getOne(id);
            return new ViewAsPdf(consulta);
        }

    }
}