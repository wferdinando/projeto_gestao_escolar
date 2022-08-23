using GestaoEscolar.Models;
using GestaoEscolar.Models.ViewModels;
using GestaoEscolar.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEscolar.Controllers;

public class MatriculasController : Controller
{
    private readonly MatriculaServices _matriculaService;
    private readonly AlunoServices _alunosServices;
    private readonly TurmaServices _turmasServices;

    public MatriculasController(MatriculaServices matriculaService, TurmaServices turmaService, AlunoServices alunoServices)
    {
        _matriculaService = matriculaService;
        _turmasServices = turmaService;
        _alunosServices = alunoServices;

    }

    public async Task<IActionResult> Index()
    {
        var matriculas = await _matriculaService.FindAllAsync();
        return View(matriculas);
    }

    public async Task<IActionResult> Matricular(int id)
    {
        ViewBag.AlunoSelecionado = await _alunosServices.FindByIdAsync(id);
        ViewBag.DropTurmas = await _turmasServices.FindAllAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Matricular(Matricula matricula, int? id)
    {
        var listaMatricula = await _matriculaService.FindAllAsync();
        bool jaMatriculado = listaMatricula.Exists(x => x.AlunoId == matricula.AlunoId && x.TurmaId == matricula.TurmaId);

        if (jaMatriculado)

        {
            ViewBag.AlunoSelecionado = await _alunosServices.FindByIdAsync(id.Value);
            ViewBag.DropTurmas = await _turmasServices.FindAllAsync();
            ViewData["Aviso"] = "Aluno já matriculado nesta turma!";
            return View();
        }

        await _matriculaService.InsertAsync(matricula);
        return RedirectToAction(nameof(Index));
    }

}
