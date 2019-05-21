using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Practica.Models;

namespace Practica.Controllers
{
    [Authorize]
    public class FacturaController : Controller
    {
        private readonly ic_cobros_pagosEntities db = new ic_cobros_pagosEntities();

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        //
        // GET: /Factura/
        public ActionResult Index()
        {
            var user = db.Usuario.FirstOrDefault(m => m.nombre_usuario == "cypadmin");
            if (user != null) AuthenticationManager.SignIn();
            return View();
        }
    }
}