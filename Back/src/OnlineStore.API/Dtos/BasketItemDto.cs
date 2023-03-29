using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProdutoNome { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Preço tem de ser superior a zero")]
        public decimal Preco { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantidade deve ser pelo menos 1")]
        public int Quantidade { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Categoria { get; set; }
    }
}