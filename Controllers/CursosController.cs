using GestaoEscolar.Models;
using GestaoEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.Controllers;

public class CursosController : Controller
{
    private readonly CursoServices _cursoServices;

    public CursosController(CursoServices cursoServices)
    {
        _cursoServices = cursoServices;
    }

    public async Task<IActionResult> Index()
    {
        var cursos = await _cursoServices.FindAllAsync();
        return View(cursos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Curso curso)
    {
        if (ModelState.IsValid)
        {
            await _cursoServices.InsertAsync(curso);
            return RedirectToAction(nameof(Index));
        }
        return View("Create");

    }

}
