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
    
    public partial class Materia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materia()
        {
            this.Cursando = new HashSet<Cursando>();
            this.Grupo = new HashSet<Grupo>();
            this.HistorialAcademico = new HashSet<HistorialAcademico>();
            this.Tutorias = new HashSet<Tutorias>();
        }
    
        public int idMateria { get; set; }
        public int idCarrera { get; set; }
        public string NombreMateria { get; set; }
        public string Semestre { get; set; }
        public string AbreviacionMateria { get; set; }
        public string Clave { get; set; }
        public string Creditos { get; set; }
        public string HrsTeoricas { get; set; }
        public string HrsPracticas { get; set; }
        public string PlanEstudios { get; set; }
    
        public virtual Carrera Carrera { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cursando> Cursando { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grupo> Grupo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tutorias> Tutorias { get; set; }
    }
}
