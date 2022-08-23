using GestaoEscolar.Context;
using GestaoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Services;

public class CursoDisciplinaService
{
    private readonly AppDbContext _context;

    public CursoDisciplinaService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<CursoDisciplina>> FindAllAsync()
    {
        return await _context.CursoDisciplinas
                .Include(a => a.Curso)
                .Include(t => t.Disciplina)
                .OrderByDescending(x => x.Curso.Nome)
                .ToListAsync();
    }

    public async Task InsertAsync(CursoDisciplina obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }
}
