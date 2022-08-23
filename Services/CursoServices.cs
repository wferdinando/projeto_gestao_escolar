using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEscolar.Context;
using GestaoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Services
{
    public class CursoServices
    {
        private readonly AppDbContext _context;

        public CursoServices(AppDbContext context)
        {
            _context = context;
        }
 
        public async Task<List<Curso>> FindAllAsync()
        {
            return await _context.Cursos.Include(c => c.Turmas).ToListAsync();
        }

        public async Task InsertAsync(Curso obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

    }
}