using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEscolar.Models
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<CursoDisciplina> CursosDisciplinas {get; set;}
        public virtual ICollection<Turma> Turmas {get; set;}
    }
}