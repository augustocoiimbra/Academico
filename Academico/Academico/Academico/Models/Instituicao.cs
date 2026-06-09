using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Instituicao
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        public string? Endereco { get; set; }

        // Navegabilidade: uma Instituicao possui muitos Departamentos
        public virtual ICollection<Departamento>? Departamentos { get; set; }
    }
}
