//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Catalogo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string complemento { get; set; }
        public string estado { get; set; }
        public Nullable<int> id_catalogo_padre { get; set; }
        public Nullable<bool> es_padre { get; set; }
        public Nullable<bool> es_editable { get; set; }
    }
}