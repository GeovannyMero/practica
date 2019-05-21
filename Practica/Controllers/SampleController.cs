using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Practica.Models;


namespace Practica.Controllers
{
    [Authorize]
    public class SampleController : Controller
    {

        private ic_cobros_pagosEntities db = new ic_cobros_pagosEntities();
        //
        // GET: /Sample/

        public ActionResult Index()
        {
            UserModel user = new UserModel();

            var userList = new List<UserModel>
            {
                new UserModel()
                {
                    UserId = 1,
                    UserName = "Geovanny Mero",
                    Company = "Banco Machala"
                },
                new UserModel()
                {
                    UserId = 2,
                    UserName = "Jefferson Mero",
                    Company = "Claro"
                },
                new UserModel()
                {
                    UserId = 3,
                    UserName = "johanna Robles",
                    Company = "Barrio"
                }
            };





            return View(userList.ToList());
        }

        public ActionResult gotoDevEx()
        {
            UserModel user = new UserModel();

            var userList = new List<UserModel>
                {
            new UserModel()
            {
                UserId = 1,
                UserName = "Geovanny Mero",
                Company = "Banco Machala"
            },
            new UserModel()
            {
                UserId = 2,
                UserName = "Jefferson Mero",
                Company = "Claro"
            },
            new UserModel()
            {
                UserId = 3,
                UserName = "johanna Robles",
                Company = "Barrio"
            }
        };
            string userJson = JsonConvert.SerializeObject(userList.ToList());


            return PartialView();


        }

        [HttpGet]
        public JsonResult datos()
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

        [HttpPost]
        public ActionResult insert(Catalogo catalogo)
        {
            return (Index());
        }

        [HttpPost]
        public ActionResult Update(Catalogo catalogo)
        {
            var ca = db.Catalogo.FirstOrDefault(c => c.id == catalogo.id);

            if (ca != null)
            {
                ca.codigo = string.IsNullOrEmpty(catalogo.codigo) ? ca.codigo : catalogo.codigo;
                ca.nombre = string.IsNullOrEmpty(catalogo.nombre) ? ca.nombre : catalogo.nombre;
                ca.complemento = string.IsNullOrEmpty(catalogo.complemento) ? ca.complemento : catalogo.complemento;
                ca.descripcion = string.IsNullOrEmpty(catalogo.descripcion) ? ca.descripcion : catalogo.descripcion;
                ca.es_editable = string.IsNullOrEmpty(catalogo.es_editable.ToString()) ? ca.es_editable : catalogo.es_editable;
                ca.es_padre = string.IsNullOrEmpty(catalogo.es_padre.ToString()) ? ca.es_padre : catalogo.es_padre;
                ca.estado = string.IsNullOrEmpty(catalogo.estado) ? ca.estado : catalogo.estado;
                ca.id_catalogo_padre = string.IsNullOrEmpty(catalogo.id_catalogo_padre.ToString())
                    ? ca.id_catalogo_padre
                    : catalogo.id_catalogo_padre;
            }
            db.SaveChanges();
            return null;
        }

        public ActionResult PrActionResult()
        {
            return View();
        }
    }


}