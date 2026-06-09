# Academico - ASP.NET MVC com Entity Framework Core

Projeto desenvolvido como resolução dos exercícios propostos nos slides de aula da disciplina de Desenvolvimento Web com ASP.NET MVC e Entity Framework Core.

## Funcionalidades

- CRUD completo de **Alunos**
- CRUD completo de **Instituições**
- CRUD completo de **Departamentos** (relacionado a Instituição — 1:N)
- CRUD completo de **Cursos** (relacionado a Departamento — 1:N)

## Tecnologias

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core 8
- SQL Server LocalDB
- Bootstrap 5

## Como executar

1. Clone o repositório
2. Abra no Visual Studio
3. Certifique-se de ter o SQL Server LocalDB instalado
4. Execute no Console do Gerenciador de Pacotes:
   ```
   update-database
   ```
5. Execute o projeto (F5)

O banco de dados será criado automaticamente e populado com dados iniciais.
