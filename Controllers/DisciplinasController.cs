using GestaoEscolar.Models;
using GestaoEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.Controllers;

public class DisciplinasController : Controller
{
    private readonly DisciplinaService _disciplinaService;

    public DisciplinasController(DisciplinaService disciplinaService)
    {
        _disciplinaService = disciplinaService;
    }

    public async Task<IActionResult> Index()
    {
        var disciplinas = await _disciplinaService.FindAllAsync();
        return View(disciplinas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Disciplina disciplina)
    {
        if (ModelState.IsValid)
        {
            await _disciplinaService.InsertAsync(disciplina);
            return RedirectToAction(nameof(Index));
        }
        return View("Create");

    }

}
