using Core.Models.Compras;

namespace OnlineStore.API.Dtos
{
    public class CompraToReturnDto
    {
        public int Id { get; set; }
        public string ClienteEmail { get; set; }
        public DateTime CompraData { get; set; }
        public Morada MoradaEnvio { get; set; }
        public string MetodoEnvio { get; set; }
        public decimal PrecoEnvio { get; set; }
        public IReadOnlyList<CompraItemDto> CompraItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}