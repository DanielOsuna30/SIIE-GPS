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
    
    public partial class Tutorias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tutorias()
        {
            this.AlumnosTutoriaRelationship = new HashSet<AlumnosTutoriaRelationship>();
            this.HorarioTutorias = new HashSet<HorarioTutorias>();
        }
    
        public int Id { get; set; }
        public int MateriaId { get; set; }
        public int TutorId { get; set; }
        public string Name { get; set; }
    
        public virtual Materia Materia { get; set; }
        public virtual Tutores Tutores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnosTutoriaRelationship> AlumnosTutoriaRelationship { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioTutorias> HorarioTutorias { get; set; }
    }
}
