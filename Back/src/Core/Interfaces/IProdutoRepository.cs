using Core.Models;

namespace Core.Interfaces
{
    public interface IProdutoRepository //Repositório a trabalhar com todos os models para já.
    {
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<IReadOnlyList<Produto>> GetProdutosAsync();
        Task<IReadOnlyList<ProdutoCategoria>> GetCategoriasAsync();
        Task<IReadOnlyList<ProdutoMarca>> GetMarcasAsync();
    }
}