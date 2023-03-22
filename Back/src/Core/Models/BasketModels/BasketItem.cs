namespace Core.Models.Basket
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProdutoNome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string PictureUrl { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
    }
}