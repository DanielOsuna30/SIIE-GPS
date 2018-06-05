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
    
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            this.Cursando = new HashSet<Cursando>();
            this.HistorialAcademico = new HashSet<HistorialAcademico>();
            this.AlumnosTutoriaRelationship = new HashSet<AlumnosTutoriaRelationship>();
        }
    
        public int idAlumno { get; set; }
        public int idCarrera { get; set; }
        public string noControl { get; set; }
        public string Semestre { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Preparatoria { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string NombrePadre { get; set; }
        public string NombreMadre { get; set; }
        public string TelefonoPadre { get; set; }
        public string TelefonoMadre { get; set; }
        public string OtroContacto { get; set; }
    
        public virtual Carrera Carrera { get; set; }
        public virtual Loginn Loginn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cursando> Cursando { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialAcademico> HistorialAcademico { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnosTutoriaRelationship> AlumnosTutoriaRelationship { get; set; }
    }
}
