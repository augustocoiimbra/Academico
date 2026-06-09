using Academico.Models;

namespace Academico.Data
{
    public class AcademicoDbInitializer
    {
        public static void Initialize(AcademicoContext context)
        {
            context.Database.EnsureCreated();

            // Seed Alunos
            if (!context.Alunos.Any())
            {
                var alunos = new Aluno[]
                {
                    new Aluno
                    {
                        Nome = "AlunoTeste",
                        Email = "alunoTeste@mail.com",
                        Telefone = "999999999",
                        Endereco = "Rua Teste",
                        Complemento = "Casa",
                        Bairro = "Bairro Teste",
                        Municipio = "Municipio Teste",
                        Uf = "UF",
                        Cep = "99999999"
                    }
                };
                foreach (var aluno in alunos)
                {
                    context.Alunos.Add(aluno);
                    context.SaveChanges();
                }
            }

            // Seed Instituicoes
            if (!context.Instituicoes.Any())
            {
                var instituicoes = new Instituicao[]
                {
                    new Instituicao { Nome = "FOA",   Endereco = "Av. Paulo Erlei Alves Abrantes, 1325" },
                    new Instituicao { Nome = "SENAI", Endereco = "Rua Exemplo, 100" },
                    new Instituicao { Nome = "UGB",   Endereco = "Rua Exemplo, 200" }
                };
                foreach (var inst in instituicoes)
                {
                    context.Instituicoes.Add(inst);
                    context.SaveChanges();
                }
            }

            // Seed Departamentos
            if (!context.Departamentos.Any())
            {
                var inst = context.Instituicoes.First();
                var departamentos = new Departamento[]
                {
                    new Departamento { Nome = "Sistemas de Informacao", InstituicaoId = inst.Id },
                    new Departamento { Nome = "Engenharia de Software",  InstituicaoId = inst.Id }
                };
                foreach (var dep in departamentos)
                {
                    context.Departamentos.Add(dep);
                    context.SaveChanges();
                }
            }

            // Seed Cursos
            if (!context.Cursos.Any())
            {
                var dep = context.Departamentos.First();
                var cursos = new Curso[]
                {
                    new Curso { Nome = "Programação Web",      CargaHoraria = 60, DepartamentoId = dep.Id },
                    new Curso { Nome = "Banco de Dados",       CargaHoraria = 80, DepartamentoId = dep.Id }
                };
                foreach (var curso in cursos)
                {
                    context.Cursos.Add(curso);
                    context.SaveChanges();
                }
            }
        }
    }
}
