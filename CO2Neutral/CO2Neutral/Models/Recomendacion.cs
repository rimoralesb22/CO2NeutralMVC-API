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
    
    public partial class Recomendacion
    {
        public int idRecomendacion { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idCategoria { get; set; }
    
        public virtual CategoriaRecomendacion CategoriaRecomendacion { get; set; }
    }
}
