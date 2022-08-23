using GestaoEscolar.Models;
using GestaoEscolar.Models.ViewModels;
using GestaoEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.Controllers;

public class CursosDisciplinasController : Controller
{

    private readonly CursoServices _cursosServices;
    private readonly DisciplinaService _disciplinaServices;
    private readonly CursoDisciplinaService _cdServices;

    public CursosDisciplinasController(CursoServices cursosServices, DisciplinaService disciplinaServices, CursoDisciplinaService cdServices)
    {
        _cursosServices = cursosServices;
        _disciplinaServices = disciplinaServices;
        _cdServices = cdServices;
    }

    public async Task<IActionResult> Index()
    {
        var cursoDisciplinas = await _cdServices.FindAllAsync();
        return View(cursoDisciplinas);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.DropCursos = await _cursosServices.FindAllAsync();
        ViewBag.DropDisciplinas = await _disciplinaServices.FindAllAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CursoDisciplina cd)
    {
        await _cdServices.InsertAsync(cd);
        return RedirectToAction(nameof(Index));
    }

}
