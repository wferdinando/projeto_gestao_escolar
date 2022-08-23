using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoEscolar.Models.ViewModels
{
    public class TurmaFormViewModel
    {
        public Turma Turma { get; set; }
        public ICollection<Curso> Cursos{ get; set; }
    }
}