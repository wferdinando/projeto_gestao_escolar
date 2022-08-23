using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEscolar.Models
{
    public class AlunoDisciplina
    {
        [Key]
        public int AlunoDisciplinaId { get; set; }

        [ForeignKey("Matricula")]
        public int MatriculaId { get; set; }
        public virtual Matricula Matricula { get; set; }

        [ForeignKey("Disciplina")]
        public int DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        public float Nota { get; set; }
    }
}