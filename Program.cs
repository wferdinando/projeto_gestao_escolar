using GestaoEscolar.Context;
using GestaoEscolar.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ContextConfiguration PostgresSql
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("StringConnection")));

builder.Services.AddScoped<AlunoServices, AlunoServices>();
builder.Services.AddScoped<TurmaServices, TurmaServices>();
builder.Services.AddScoped<MatriculaServices, MatriculaServices>();
builder.Services.AddScoped<CursoServices, CursoServices>();
builder.Services.AddScoped<DisciplinaService, DisciplinaService>();
builder.Services.AddScoped<CursoDisciplinaService, CursoDisciplinaService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
