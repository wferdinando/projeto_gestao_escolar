using GestaoEscolar.Models;
using GestaoEscolar.Models.ViewModels;
using GestaoEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.Controllers;

public class TurmasController : Controller
{
    private readonly TurmaServices _turmaServices;
    private readonly CursoServices _cursoServices;

    public TurmasController(TurmaServices turmaServices, CursoServices cursoServices)
    {
        _turmaServices = turmaServices;
        _cursoServices = cursoServices;
    }

    public async Task<IActionResult> Index()
    {
        var turmas = await _turmaServices.FindAllAndCursoAsync();
        return View(turmas);
    }

    public async Task<IActionResult> Create()
    {
        var cursos = await _cursoServices.FindAllAsync();
        var viewModel = new TurmaFormViewModel { Cursos = cursos };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Turma turma)
    {
        if (ModelState.IsValid)
        {
            await _turmaServices.InsertAsync(turma);
            return RedirectToAction(nameof(Index));
        }
        return View("Create");

    }

}
