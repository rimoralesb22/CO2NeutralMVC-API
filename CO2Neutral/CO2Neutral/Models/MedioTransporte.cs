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
    
    public partial class MedioTransporte
    {
        public int idCalculdora { get; set; }
        public int idFrecuencias { get; set; }
        public Nullable<int> kilometraje { get; set; }
        public Nullable<int> cantidadVeces { get; set; }
        public int idMedios { get; set; }
        public int idMedioTransporte { get; set; }
    
        public virtual Calculadora Calculadora { get; set; }
        public virtual listaFrecuencias listaFrecuencias { get; set; }
        public virtual listaMedios listaMedios { get; set; }
    }
}
