using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Produto : Base
    {
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Preco { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
