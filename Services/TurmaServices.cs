using GestaoEscolar.Context;
using GestaoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Services
{
    public class TurmaServices
    {

        private readonly AppDbContext _context;

        public TurmaServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Turma>> FindAllAsync()
        {
            return await _context.Turmas.ToListAsync();
        }

        public async Task<List<Turma>> FindAllAndCursoAsync()
        {
            return await _context.Turmas.Include(c => c.Curso)
            .ToListAsync();
        }

        public async Task<Turma> FindByIdAsync(int id)
        {
            return await _context.Turmas.Include(obj => obj.Curso)
            .FirstOrDefaultAsync(obj => obj.TurmaId == id);
        }

        public async Task InsertAsync(Turma obj)
        {
            await _context.Turmas.AddAsync(obj);
            _context.SaveChanges();
        }
    }
}