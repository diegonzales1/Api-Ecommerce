using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;

namespace Repositorio.Repositorios
{
    public class CarrinhoRepositorio : BaseRepositorio<Carrinho>, ICarrinhoRepositorio
    {
        public CarrinhoRepositorio(BancoContexto bancoContexto) : base(bancoContexto) { }
    }

}
