using CadastroMotorista.Util;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroMotorista.Models
{
    public class Motorista
    {
        private int? _idade = 0;
        [Key]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Cpf]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} permite no máximo {1} caracteres")]
        public string Nome { get; set; }
        [Range(18, 100, ErrorMessage ="{0} inválida")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? Idade 
        {
            get 
            {
                return _idade;
            }
            set 
            {
                _idade =  value == null? 0 : value;
            } 
        }
        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }


        public void RemoverMascaraCpf()
        {
            if (string.IsNullOrEmpty(this.Cpf)) return;
            this.Cpf = this.Cpf.Replace(".", "").Replace("-","");
        }
    }
}
