using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;

namespace Practica
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public ActionResult prueba()
        {
            string mensaje = string.Format("Hola prueba {0}", 1);

            return null;
        }

        protected void submit(object sender, EventArgs e)
        {
            string mensaje = string.Format("Hola {0}", "mundo");
            Console.WriteLine(mensaje);


        }

    }
}