using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEscolar.Models
{
    public class Disciplina
    {
        [Key]
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }

        public ICollection<CursoDisciplina> CursoDisciplinas { get; set; }
        public virtual ICollection<AlunoDisciplina> AlunosDisciplinas { get; set; } = new List<AlunoDisciplina>(); 
    }
}