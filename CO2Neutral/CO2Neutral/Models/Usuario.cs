//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CO2Neutral.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Calculadora = new HashSet<Calculadora>();
        }
    
        public int idUsuario { get; set; }
        public string contrasenna { get; set; }
    
        public virtual ICollection<Calculadora> Calculadora { get; set; }
    }
}
