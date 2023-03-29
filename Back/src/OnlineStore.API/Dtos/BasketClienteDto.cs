using System.ComponentModel.DataAnnotations;

namespace OnlineStore.API.Dtos
{
    public class BasketClienteDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}