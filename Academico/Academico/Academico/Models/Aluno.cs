using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        public int AlunoID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Municipio { get; set; }

        public string? Uf { get; set; }

        public string? Cep { get; set; }
    }
}
