using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEscolar.Models
{
    public class CursoDisciplina
    {
        [Key]
        public int CursoDisciplinaId { get; set; }
       
        [ForeignKey("Curso")]
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}