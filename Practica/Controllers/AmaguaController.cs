using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica.Migrations;
using Practica.ServiceAmaguaCliente;
using Practica.Models;
using cuotasConsulta = Practica.ServiceAmaguaCliente.cuotasConsulta;
using pagoCabeceraRes = Practica.Models.pagoCabeceraRes;

namespace Practica.Controllers
{
    public class AmaguaController : Controller
    {
        //usuaio y contraseña
        string userAmagua = ConfigurationManager.AppSettings["userAmagua"].ToString();
        string passwordAmagua = ConfigurationManager.AppSettings["passwordAmagua"].ToString();

        // GET: /Amagua/
        public ActionResult Index()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            AmkPagoExternoWSClient serviceAmagua = new AmkPagoExternoWSClient();
            saldoRespuesta saldoRespuesta;
            inmuebleRespuesta inmueble;
            SaldosRespuesta respuesta = new SaldosRespuesta();
            List<SaldosRespuesta> listaSaldo = new List<SaldosRespuesta>();
            if (User.Identity.IsAuthenticated)
            {

            }

            try
            {
                saldoRespuesta = serviceAmagua.consultarSaldo(userAmagua, passwordAmagua, 37379);
                inmueble = serviceAmagua.consultaInfoCliente(userAmagua, passwordAmagua, 37379);

                serviceAmagua.Close();
                if (saldoRespuesta.cuotasConvenio != null || saldoRespuesta.facturas != null)
                {
                    respuesta.baseGravableTotalField = saldoRespuesta.baseGravableTotal;
                    respuesta.baseNoGravableTotalField = saldoRespuesta.baseNoGravableTotal;
                    respuesta.saldoTotalField = saldoRespuesta.saldoTotal;
                    respuesta.cuotasConvenioField = saldoRespuesta.cuotasConvenio;
                    respuesta.facturasField = saldoRespuesta.facturas;
                    ViewBag.Mensaje = saldoRespuesta.cabecera.mensajeRespuesta;
                    listaSaldo.Add(respuesta);


                }
                else
                {
                    ViewBag.Mensaje = saldoRespuesta.cabecera.mensajeRespuesta;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return View(listaSaldo);
        }

        [HttpGet]
        public ActionResult Pago()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            AmkPagoExternoWSClient serviceAmagua = new AmkPagoExternoWSClient();
            pagoRespuesta pagoRespuesta = new pagoRespuesta();
            pagoInputType pagoInputType1 = new pagoInputType();
            pagoInputType1.inmCodigo = 37379;
            pagoInputType1.valor = 1;
            pagoInputType1.codTrans = "1993";
            //pagoInputType1.documento = 4781827;
            //pagoInputType1.documentoSpecified = true;

            pagoRespuestas res = new pagoRespuestas();
            try
            {
                pagoRespuesta = serviceAmagua.registrarPago(userAmagua, passwordAmagua, pagoInputType1);
                if (pagoRespuesta.pagos == null)
                {
                    res.cabeceraField.mensajeRespuestaField = pagoRespuesta.cabecera.mensajeRespuesta;
                    res.cabeceraField.codigoRespuestaField = pagoRespuesta.cabecera.codigoRespuesta;
                    //ViewBag.mensaje = res.cabeceraField.mensajeRespuestaField;
                    if (pagoRespuesta.pagos != null)
                    {
                        int co = pagoRespuesta.pagos[0].codigoPago;
                    }
                }
                else
                {
                    ViewBag.mensaje = pagoRespuesta.cabecera.mensajeRespuesta;
                    //res.cabeceraField.codigoRespuestaField = pagoRespuesta.cabecera.codigoRespuesta;
                   
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);

            }

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult Anular()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            AmkPagoExternoWSClient serviceAmagua = new AmkPagoExternoWSClient();
            ServiceAmaguaCliente.pagoCabeceraRes pago = new ServiceAmaguaCliente.pagoCabeceraRes();
            try
            {
                pago = serviceAmagua.anularPago(userAmagua, passwordAmagua, 0, "026", "1993");


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Redirect("Index");
        }
    }
}