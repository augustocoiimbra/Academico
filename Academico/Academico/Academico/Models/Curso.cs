using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Curso
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A carga horária é obrigatória.")]
        [Display(Name = "Carga Horária")]
        public int CargaHoraria { get; set; }

        // Chave estrangeira para Departamento
        public long? DepartamentoId { get; set; }

        // Propriedade de navegação para Departamento
        [DisplayName("Departamento")]
        public Departamento? Departamento { get; set; }
    }
}
