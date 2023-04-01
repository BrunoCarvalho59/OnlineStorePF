using System.Text.Json;
using Core.Models;
using Core.Models.Compras;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if(!context.Marcas.Any())
            {
                var marcasData = File.ReadAllText("../Infrastructure/Data/SeedData/marcas.json");
                var marcas = JsonSerializer.Deserialize<List<ProdutoMarca>>(marcasData);
                context.Marcas.AddRange(marcas);
            }

            if(!context.Categorias.Any())
            {
                var categoriasData = File.ReadAllText("../Infrastructure/Data/SeedData/categorias.json");
                var categorias = JsonSerializer.Deserialize<List<ProdutoCategoria>>(categoriasData);
                context.Categorias.AddRange(categorias);
            }

            if(!context.Produtos.Any()) //É importante que este Seed seja feito em último pelo motivo de este json depender dos dois anteriores
            {
                var produtosData = File.ReadAllText("../Infrastructure/Data/SeedData/produtos.json");
                var produtos = JsonSerializer.Deserialize<List<Produto>>(produtosData);
                context.Produtos.AddRange(produtos);
            }
            
            if(!context.MetodosEnvio.Any())
            {
                var envioData = File.ReadAllText("../Infrastructure/Data/SeedData/envio.json");
                var metodos = JsonSerializer.Deserialize<List<MetodoEnvio>>(envioData);
                context.MetodosEnvio.AddRange(metodos);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}