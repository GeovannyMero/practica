﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.EntityFramework;

namespace Practica.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;


    public partial class ic_cobros_pagosEntities : IdentityDbContext<ApplicationUser>
    {
        public ic_cobros_pagosEntities()
            : base("name=ic_cobros_pagosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Catalogo> Catalogo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
