//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIIE_Tutorias.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HorarioTutorias
    {
        public int TutoriaId { get; set; }
        public int Dia { get; set; }
        public string Horario { get; set; }
    
        public virtual Tutorias Tutorias { get; set; }
    }
}
