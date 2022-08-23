using GestaoEscolar.Context;
using GestaoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Services;

public class AlunoServices
{
    private readonly AppDbContext _context;

    public AlunoServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Aluno>> FindAllAsync()
    {
        return await _context.Alunos.ToListAsync();
    }

    public async Task<Aluno> FindByIdAsync(int id)
    {

        return await _context.Alunos.Include(obj => obj.Matriculas).FirstOrDefaultAsync(obj => obj.AlunoId == id);
    }
    
    public async Task InsertAsync(Aluno obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }
}
