// <auto-generated />
using GestaoEscolar.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestaoEscolar.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GestaoEscolar.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlunoId"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("GestaoEscolar.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoDisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlunoDisciplinaId"));

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("integer");

                    b.Property<int>("MatriculaId")
                        .HasColumnType("integer");

                    b.Property<float>("Nota")
                        .HasColumnType("real");

                    b.HasKey("AlunoDisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("MatriculaId");

                    b.ToTable("AlunoDisciplina");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CursoId"));

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("CursoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("GestaoEscolar.Models.CursoDisciplina", b =>
                {
                    b.Property<int>("CursoDisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CursoDisciplinaId"));

                    b.Property<int>("CursoId")
                        .HasColumnType("integer");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("integer");

                    b.HasKey("CursoDisciplinaId");

                    b.HasIndex("CursoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("CursoDisciplinas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DisciplinaId"));

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("DisciplinaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Matricula", b =>
                {
                    b.Property<int>("MatriculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MatriculaId"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("integer");

                    b.Property<int>("TurmaId")
                        .HasColumnType("integer");

                    b.HasKey("MatriculaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TurmaId"));

                    b.Property<int>("CursoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("TurmaId");

                    b.HasIndex("CursoId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("GestaoEscolar.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoEscolar.Models.Matricula", "Matricula")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disciplina");

                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("GestaoEscolar.Models.CursoDisciplina", b =>
                {
                    b.HasOne("GestaoEscolar.Models.Curso", "Curso")
                        .WithMany("CursosDisciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoEscolar.Models.Disciplina", "Disciplina")
                        .WithMany("CursoDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Matricula", b =>
                {
                    b.HasOne("GestaoEscolar.Models.Aluno", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestaoEscolar.Models.Turma", "Turma")
                        .WithMany("Matriculas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Turma", b =>
                {
                    b.HasOne("GestaoEscolar.Models.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Aluno", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Curso", b =>
                {
                    b.Navigation("CursosDisciplinas");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Disciplina", b =>
                {
                    b.Navigation("AlunosDisciplinas");

                    b.Navigation("CursoDisciplinas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Matricula", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("GestaoEscolar.Models.Turma", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
