//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIIE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cursando
    {
        public int idCursando { get; set; }
        public int idGrupo { get; set; }
        public int idAlumno { get; set; }
        public int idMateria { get; set; }
        public string Semestre { get; set; }
        public string Año { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
