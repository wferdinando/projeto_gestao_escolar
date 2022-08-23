using System.ComponentModel.DataAnnotations;

namespace GestaoEscolar.Models;

public class Aluno
{
    [Key]
    public int AlunoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public virtual List<Matricula> Matriculas { get; set; } = new List<Matricula>();
    
}
