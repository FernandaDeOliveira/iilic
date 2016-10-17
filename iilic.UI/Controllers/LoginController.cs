using iilic.Core;
using iilic.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace iilic.UI.Controllers
{
    public class LoginController : Controller
    {
        loginRepositorio log = new loginRepositorio();
        // GET: Login
        public ActionResult Index()
        {
            return View();


        }

        public ActionResult teste()
        {
            return View();

        }
        /// <summary>
        /// tentativa de imagem
        /// </summary>
        public void GetImagem()
        {
            WebImage wbImage = new WebImage("~/Imagem/psi.jpg");
            wbImage.Resize(300, 300);
            wbImage.FileName = "psi.jpg";
            wbImage.Write();
        }

        [HttpPost]
        public ActionResult Autentica(Login pLogin)
        {
            if (pLogin.valorLog == 1)
            {
                var userTryLogin = log.Busca(pLogin);

                if (userTryLogin != null)
                {
                    //grava o cookie do user
                    FormsAuthentication.SetAuthCookie(pLogin.login, false);
                    TempData["idlogin"] = pLogin.idLogin;
                    //redireciona para a mainpage
                    return RedirectToAction("IndexADM", "Administrador");
                    
                }else
                    ViewBag.erroulogin = "Usuário ou senha não encontrados";
                         return View("Index");
            }
            else
            {
             //   ViewBag.erroulogin = "Usuário ou senha não encontrados";
               // return View("Index");
            }
            if (pLogin.valorLog == 2)
            {
                var userTryLogin = log.Busca(pLogin);

                if (userTryLogin != null)
                {
                    //grava o cookie do user
                    FormsAuthentication.SetAuthCookie(pLogin.login, false);
                    //redireciona para a mainpage
                    return RedirectToAction("IndexTer", "Terapeuta");
                }
                else
                {
                    ViewBag.erroulogin = "Usuário ou senha não encontrados";
                    return View("Index");
                }
                
            }
            return View("Index");
        }

        public ActionResult CriarLogin()
            ///ver se nao tem q passar id
        {
            return View("CriarLogin");
        }

        [HttpPost]
        public ActionResult CriarLog(Login pLogin)
        {
            if (pLogin.valorLog == 1)
            {
                log.Criar(pLogin);
                RedirectToAction("Index");
            }else
            {
               
            }
            if (pLogin.valorLog == 2)
            {
                log.Criar(pLogin);
                RedirectToAction("Index");
            }
                return View("Index");
        }
    }
}