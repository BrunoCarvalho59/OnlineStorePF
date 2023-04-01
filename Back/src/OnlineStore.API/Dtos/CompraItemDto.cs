namespace OnlineStore.API.Dtos
{
    public class CompraItemDto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public string FotoUrl { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}