using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Practica.Models;

namespace Practica.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {

        private ic_cobros_pagosEntities db = new ic_cobros_pagosEntities();
        //
        // GET: /Usuario/
        public ActionResult Index()
        {

            return View();
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //[HttpPost]
        //public ActionResult login(Usuario usuario)
        //{
        //    var user = db.Usuario.FirstOrDefault(m => m.nombre_usuario == usuario.nombre_usuario);
        //    if (user != null)
        //    {
        //        AuthenticationManager.SignIn();
                
        //    }
        //}
	}
}