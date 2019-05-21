using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica.Models;

namespace Practica.Controllers
{
    public class CatalogoController : Controller
    {

        private ic_cobros_pagosEntities db = new ic_cobros_pagosEntities();

        //
        // GET: /Catalogo/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Load()
        {
            var u = User.Identity.Name;
            List<Catalogo> listaCatalogos = new List<Catalogo>();
            var consulta = (from c in db.Catalogo
                where c.estado == "Activo"
                select c).Take(10);
            listaCatalogos = consulta.ToList();

            return View(listaCatalogos);

        }

       
    }
}