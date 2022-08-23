using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoEscolar.Context;
using GestaoEscolar.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoEscolar.Services
{
    public class DisciplinaService
    {
        private readonly AppDbContext _context;

        public DisciplinaService(AppDbContext context)
        {
            _context = context;
        }
 
        public async Task<List<Disciplina>> FindAllAsync()
        {
            return await _context.Disciplinas.ToListAsync();
        }

        public async Task InsertAsync(Disciplina obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

    }
}