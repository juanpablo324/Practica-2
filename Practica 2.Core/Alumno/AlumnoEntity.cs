using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EIN.Enumeradores;

namespace EIN.Entidades
{
    [Table("Alumno")]
    public class AlumnoEntity
    {
        [Key]public int Id { get; set; }
        
        [Required, StringLength (10)] public string NumeroCuenta { get; set; }

        [Required, StringLength (30)]public string Nombre { get; set; }

        [Required, StringLength (30)]public string ApellidoPaterno { get; set; }

        [StringLength (30)]public string  ApellidoMaterno { get; set; }

        [StringLength (10)]public string Telefono { get; set; }

        public SexoEnum Sexo {  get; set; } 

        public int IdGrupo { get; set; }

        public bool EstaActivo { get; set; }

        [ForeignKey("IdGrupo")]public virtual GrupoEntity Grupo { get; set; }

    }
}
