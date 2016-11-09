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


        public ActionResult TesteRecibo()
        {
            
            return View();
        }
        protected void btnImprimir_Click(object sender, EventArgs e)

        {

           // gravaAuditoria(dados);
        }
        public ActionResult Modelo()
        {
            return View("Modelo");
        }

        /*
         * Retorna um PDF diretamente no browser com as configurações padrões
         * ViewName é setado somente para utilizar o próprio Modelo anterior
         * Caso não queira setar o ViewName, você deve gerar a view com o mesmo nome da action
         */
        public ActionResult PDFPadrao()
        {
            var pdf = new ViewAsPdf
            {
                ViewName = "Modelo"
            };
            return pdf;
        }

        /*
         * Configura algumas propriedades do PDF, inclusive o nome do arquivo gerado,
         * Porem agora ele baixa o pdf ao invés de mostrar no browser
         */
        public ActionResult PDFConfigurado()
        {
            var pdf = new ViewAsPdf
            {
                ViewName = "Modelo",
                FileName = "NomeDoArquivoPDF.pdf",
                PageSize = Size.A4,
                IsGrayScale = true,
                PageMargins = new Margins { Bottom = 5, Left = 5, Right = 5, Top = 5 },
            };
            return pdf;
        }

        /*
         * Pode passar um modelo para a view que vai ser utilizada para gerar o PDF
         */
        public ActionResult PDFComModel()
        {
            var modelo = new Usuario
            {
                Nome = "Cleyton Ferrari",
                Site = "http://cleytonferrari.com"
            };

            var pdf = new ViewAsPdf
            {
                ViewName = "Modelo",
                Model = modelo
            };

            return pdf;
        }
    }
}