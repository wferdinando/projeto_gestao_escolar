using GestaoEscolar.Models;
using GestaoEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.Controllers;

public class AlunosController : Controller
{
    private readonly AlunoServices _alunoServices;

    public AlunosController(AlunoServices alunoServices)
    {
        _alunoServices = alunoServices;
        
    }

    public async Task<IActionResult> Index()
    {
        var alunos = await _alunoServices.FindAllAsync();
        return View(alunos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Aluno aluno)
    {
        if (ModelState.IsValid)
        {
            await _alunoServices.InsertAsync(aluno);
            return RedirectToAction(nameof(Index));
        }
        return View("Create");

    }
}
