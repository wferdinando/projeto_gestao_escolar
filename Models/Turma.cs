using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEscolar.Models;

public class Turma
{
    [Key]
    public int TurmaId { get; set; }
    public string Nome { get; set; } = string.Empty;

    [ForeignKey("Curso")]
    public int CursoId { get; set; }
    public virtual Curso Curso { get; set; }

    public virtual List<Matricula> Matriculas { get; set; } = new List<Matricula>();
}