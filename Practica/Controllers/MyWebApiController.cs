using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Practica.Models;

namespace Practica.Controllers
{
    public class MyWebApiController : ApiController
    {
        private ic_cobros_pagosEntities db = new ic_cobros_pagosEntities();

        // GET api/MyWebApi
        public List<Catalogo> GetCatalogo()
        {
            return db.Catalogo.ToList();
        }

        // GET api/MyWebApi/5
        [ResponseType(typeof(Catalogo))]
        public IHttpActionResult GetCatalogo(int id)
        {
            Catalogo catalogo = db.Catalogo.Find(id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return Ok(catalogo);
        }

        // PUT api/MyWebApi/5
        public IHttpActionResult PutCatalogo(int id, Catalogo catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalogo.id)
            {
                return BadRequest();
            }

            db.Entry(catalogo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/MyWebApi
        [ResponseType(typeof(Catalogo))]
        public IHttpActionResult PostCatalogo(Catalogo catalogo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catalogo.Add(catalogo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = catalogo.id }, catalogo);
        }

        // DELETE api/MyWebApi/5
        [ResponseType(typeof(Catalogo))]
        public IHttpActionResult DeleteCatalogo(int id)
        {
            Catalogo catalogo = db.Catalogo.Find(id);
            if (catalogo == null)
            {
                return NotFound();
            }

            db.Catalogo.Remove(catalogo);
            db.SaveChanges();

            return Ok(catalogo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogoExists(int id)
        {
            return db.Catalogo.Count(e => e.id == id) > 0;
        }
    }
}