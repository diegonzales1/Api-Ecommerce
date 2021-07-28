using System.ComponentModel.DataAnnotations;

namespace E_commerce.Request
{
    public class ProdutoRequest
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve possuir no máximo 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(3, ErrorMessage = "Este campo deve possuir no máximo 3 caracteres")]
        [MinLength(2, ErrorMessage = "Este campo deve possuir no minimo 2 caracteres")]
        public string Unidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(15, ErrorMessage = "Este campo deve possuir no máximo 15 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve possuir no máximo 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve possuir no máximo 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, 99, ErrorMessage = "Entre com um número valido")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(0, 9999999999, ErrorMessage = "Entre com um número válido")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, 999999999999999, ErrorMessage = "Entre com um número válido")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int CategoriaId { get; set; }

    }
}