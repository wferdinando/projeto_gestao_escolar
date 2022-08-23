using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar.Models;

public class Matricula
{
    [Key]
    public int MatriculaId { get; set; }

    [ForeignKey("Aluno")]
    public int AlunoId { get; set; }
    public virtual Aluno Aluno { get; set; }

    [ForeignKey("Turma")]
    public int TurmaId { get; set; }
    public virtual Turma Turma { get; set; }
    public virtual ICollection<AlunoDisciplina> AlunosDisciplinas { get; set; } = new List<AlunoDisciplina>();

}
