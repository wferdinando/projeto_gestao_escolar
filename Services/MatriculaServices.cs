using GestaoEscolar.Context;
using GestaoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Services;

public class MatriculaServices
{
    private readonly AppDbContext _context;

    public MatriculaServices(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Matricula>> FindAllAsync()
    {
        return await _context.Matriculas
                .Include(a => a.Aluno)
                .Include(t => t.Turma)
                .OrderByDescending(x => x.Aluno.Nome)
                .ToListAsync();
    }

    public async Task InsertAsync(Matricula obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

}
