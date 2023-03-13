namespace Core.Models
{
    public class Produto : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }  
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string FotoUrl { get; set; }
        public ProdutoCategoria ProdutoCategoria { get; set; }
        public int ProdutoCategoriaId { get; set; }
        public ProdutoMarca ProdutoMarca { get; set; }
        public int ProdutoMarcaId { get; set; }
        
    }
}