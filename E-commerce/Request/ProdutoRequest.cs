using System.ComponentModel.DataAnnotations;

namespace E_commerce.Request
{
    public class ProdutoRequest
    {
        [Required(ErrorMessage = "Insira o nome desse produto! (Campo obrigatório.)")]
        [MaxLength(30, ErrorMessage = "Este campo deve possuir no máximo 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a unidade desse produto! (Campo obrigatório.)")]
        [MaxLength(10, ErrorMessage = "Este campo deve possuir no máximo 10 caracteres")]
        [MinLength(2, ErrorMessage = "Este campo deve possuir no minimo 2 caracteres")]
        public string Unidade { get; set; }

        [Required(ErrorMessage = "Informe a marca desse produto! (Campo obrigatório.)")]
        [MaxLength(15, ErrorMessage = "Este campo deve possuir no máximo 15 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Informe a cor desse produto! (Campo obrigatório.)")]
        [MaxLength(30, ErrorMessage = "Este campo deve possuir no máximo 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Insira uma descrição para esse produto! (Campo obrigatório.)")]
        [MaxLength(200, ErrorMessage = "Este campo deve possuir no máximo 200 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir no minimo 3 caracteres")]
        public string Descricao { get; set; }

        
        [Required(ErrorMessage = "Informe o tamanho desse produto! Ex: 38,39... (Campo obrigatório.)")]
        public int Tamanho { get; set; }

        
        [Required(ErrorMessage = "Informe a quantidade que existe no estoque! (Campo obrigatório.)")]
        public int Quantidade { get; set; }

        
        [Required(ErrorMessage = "Informe o preço desse produto! (Campo obrigatório.)")]
        public decimal Preco { get; set; }

        
        [Required(ErrorMessage = "Informe o ID da categoria desse produto! (Campo obrigatório.)")]
        public int CategoriaId { get; set; }
    }
}