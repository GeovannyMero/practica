using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica.ServiceAmaguaCliente;
using Practica.Models;

namespace Practica.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            string usuario = "MACHALA";
            string contraseña = "MMm_1234";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            AmkPagoExternoWSClient serviceAmagua = new AmkPagoExternoWSClient();
            //saldoRespuesta response;
            inmuebleRespuesta response;
            inmuebleRespuestas respuesta = new inmuebleRespuestas();
            List<inmuebleRespuestas> listaRespuesta = new List<inmuebleRespuestas>();

            try
            {

                // response = serviceAmagua.consultarSaldo(usuario, contraseña, 37379);
                response = serviceAmagua.consultaInfoCliente(usuario, contraseña, 37427);

                if (response.cabecera.idSesion != null)
                {
                    //tramaC24Respuesta.ValBase = response.baseGravableTotal;
                    //tramaC24Respuesta.ValBase = Convert.ToDouble(response.baseNoGravableTotal);
                    //tramaC24Respuesta.ValPen = Convert.ToInt32(response.saldoTotal);
                    ////tramaC24Respuesta.CantFac = Convert.ToInt32(response.cuotasConvenio);
                    //tramaC24Respuesta.CantFac = response.facturas.Length;
                    ViewBag.mensaje = response.cabecera.mensajeRespuesta;
                    respuesta.codClienteField = response.inmueble.codCliente;
                    respuesta.correoField = response.inmueble.direccion;
                    respuesta.nombreClienteField = response.inmueble.nombreCliente;
                    
                    listaRespuesta.Add(respuesta);
                }
                else
                {
                    //tramaC24Respuesta.DsReto = response.cabecera.mensajeRespuesta;
                    ViewBag.mensaje = response.cabecera.mensajeRespuesta;
                }

                //tramaC24Respuesta.CodReto = response.cabecera.codigoRespuesta;
                //tramaC24Respuesta.DsReto = response.cabecera.mensajeRespuesta;

                ViewBag.mensaje = response.cabecera.mensajeRespuesta;
                ViewBag.codigo = response.cabecera.codigoRespuesta;
                //return tramaC24Respuesta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.Error = e.Message;
            }



            return View(listaRespuesta);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (!User.Identity.IsAuthenticated)
            {

            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}