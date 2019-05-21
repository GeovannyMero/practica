using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica.Models;

namespace Practica.Controllers
{
    public class CatalogoAngularController : Controller
    {
        ic_cobros_pagosEntities db = new ic_cobros_pagosEntities();
        //
        // GET: /CatalogoAngular/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Datos()
        {
            var u = User.Identity.Name;
            UserModel user = new UserModel();
            List<Catalogo> catalogo = new List<Catalogo>();

            using (db)
            {
                var consulta = from c in db.Catalogo
                    where c.estado == "ACTIVO"
                    select c;
                catalogo = consulta.ToList();
            }

            return Json(catalogo, JsonRequestBehavior.AllowGet);
        }
    }
}