using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Practica.Models;

namespace Practica.Controllers
{
    public class Catalogo2Controller : Controller
    {
        readonly ic_cobros_pagosEntities _db = new ic_cobros_pagosEntities();
        //
        // GET: /Catalogo2/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Catalogos()
        {
            var consulta = (from c in _db.Catalogo where c.estado == "ACTIVO" select c).Take(10);

            return Json(consulta.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCatalogoById(int id)
        {
            try
            {
                var consulta = from c in _db.Catalogo where c.id == id select c;
                // var consulta = _db.Catalogo.FindAsync(id);
                return Json(consulta, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Boolean ExistCatalogo(int id)
        {
            var resultado = false;
            var consulta = _db.Catalogo.AnyAsync(x => x.id.Equals(id));
            if (consulta.Result)
            {
                resultado = true;
            }

            return resultado;
        }

        public JsonResult nuevo(Catalogo catalogo)
        {
            if (catalogo != null)
            {
                
            }
            return Json(null);
        }

      

       
    }
}