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
        adminRepositorio adm = new adminRepositorio();
        terapeutaRepositorio ter = new terapeutaRepositorio();
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
                    string nome;
                    TempData["login"] = userTryLogin.login;
                    TempData.Keep("login");

                    
                    //redireciona para a mainpage
                    return RedirectToAction("IndexADM", "Administrador");
                    
                }else
                    ViewBag.erroulogin = "Usuário ou senha não encontrados";
                         return View("Index");
            }
            else
            {
           
            }
            if (pLogin.valorLog == 2)
            {
                var userTryLogin = log.BuscaTera(pLogin);

                if (userTryLogin != null)
                {
                    //grava o cookie do user
                    FormsAuthentication.SetAuthCookie(pLogin.login, false);
                    string nome;
                    TempData["login"] = userTryLogin.login;
                    TempData.Keep("login");
                 

                    //redireciona para a mainpage
                    return RedirectToAction("IndexTerapeuta", "Terapeuta");
                }
                else
                {
                    ViewBag.erroulogin = "Usuário ou senha não encontrados";
                    return View("Index");
                }
                
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        
         }

        public ActionResult CriarLoginADM()
        {
          //  ViewBag.dados = TempData.Peek("dados");
            return View("CriarLoginADM");
        }

        [HttpPost]
        public ActionResult CriarLogADM(Administrador pAdministrador)
        {                      
            var r= log.getAllAdm(pAdministrador.acesso.login);
                if(r==true)
                {
                //dados não vao pra index
                TempData["dados"] = log.salvaDadosAdm(pAdministrador);
                TempData.Keep("dados");
                ViewBag.dados = TempData.Peek("dados");
                ViewBag.login = "Este login já existe";
                    return View("CriarLoginADM");
                }
                else
                {
                TempData.Remove("dados");
                adm.criarADM(pAdministrador);
       
            }                         
     

            return RedirectToAction("Index");
        }

        public ActionResult CriarLoginTER()
        ///ver se nao tem q passar id
        {
            return View("CriarLoginTER");
        }

        [HttpPost]
        public ActionResult CriarLogTER(Terapeuta pTerapeuta)
        {
            var r = log.getAllTer(pTerapeuta.acesso.login);
            if (r == true)
            {
                ViewBag.login = "Este login já existe";
                return View("CriarLoginADM");
            }
            else
            {
                ter.criarTer(pTerapeuta);
            }
            return RedirectToAction("Index");
        }
    }
}