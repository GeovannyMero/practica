using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica.Controllers
{
    public class PruebaModalController : Controller
    {
        //
        // GET: /PruebaModal/
        public ActionResult Index()
        {
            return PartialView("_Modal");
        }

       
	}
}