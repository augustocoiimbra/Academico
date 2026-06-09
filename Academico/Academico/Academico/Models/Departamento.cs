using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Departamento
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        // Chave estrangeira para Instituicao
        public long? InstituicaoId { get; set; }

        // Propriedade de navegação para Instituicao
        [DisplayName("Instituicao")]
        public Instituicao? Instituicao { get; set; }

        // Navegabilidade: um Departamento possui muitos Cursos
        public virtual ICollection<Curso>? Cursos { get; set; }
    }
}
