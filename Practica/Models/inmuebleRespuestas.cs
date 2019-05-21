using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica.Models
{
    public class inmuebleRespuestas
    {
        public int codClienteField { get; set; }

        public string correoField { get; set; }

        public string direccionField { get; set; }

        public string direccionInmuebleField { get; set; }

        public string docIdentificacionField { get; set; }

        public int inmCodigoField { get; set; }

        public string nombreClienteField { get; set; }

        public string telefonoField { get; set; }

        public string tipoIdentificacionField { get; set; }

    
    }

    public class SaldosRespuesta
    {
        public double baseGravableTotalField { get; set; }

        public double baseNGMasSaldoCuotasField { get; set; }

        public double baseNoGravableTotalField { get; set; }

        public facturacionCabeceraRes cabeceraField { get; set; }

        public ServiceAmaguaCliente.cuotasConsulta[] cuotasConvenioField { get; set; }

        public ServiceAmaguaCliente.facturaConsulta[] facturasField { get; set; }

        public double ivaTotalField { get; set; }

        public double saldoTotalField { get; set; }
    }
    public class facturacionCabeceraRes
    {
        public int codigoRespuestaField { get; set; }

        public string idSesionField { get; set; }

        public string mensajeRespuestaField { get; set; }
    }

    public class cuotasConsulta
    {
        public double interesField { get; set; }

        public int periodoField { get; set; }

        public double saldoField { get; set; }

        public double totalField { get; set; }

        public double valorAplicadoField { get; set; }

        public double valorAplicadoInteresField { get; set; }
    }

    public class facturaConsulta
    {

        public double baseGravableField { get; set; }

        public double baseNoGravableField { get; set; }

        public int consecutivoField { get; set; }

        public int documentoField { get; set; }

        public System.DateTime fechaVencimientoField { get; set; }

        public bool fechaVencimientoFieldSpecified { get; set; }

        public double ivaField { get; set; }

        public double pagadoField { get; set; }

        public int periodoField { get; set; }

        public double saldoField { get; set; }

        public double totalField { get; set; }
    }

    public class pagoRespuestas
    {
        public pagoCabeceraRes cabeceraField { get; set; }

        public pagoConsulta[] pagosField { get; set; }
    }

    public class pagoCabeceraRes
    {
        public int codigoRespuestaField { get; set; }

        public string idSesionField { get; set; }

        public string mensajeRespuestaField { get; set; }
    }

    public class pagoConsulta
    {
        public int codigoPagoField { get; set; }

        public decimal documentoField { get; set; }

        public bool documentoFieldSpecified { get; set; }

        public System.DateTime fechaField { get; set; }

        public bool fechaFieldSpecified { get; set; }

        public int inmCodigoField { get; set; }

        public double valorField { get; set; }
    }
}