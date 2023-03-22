using Core.Interfaces;
using Core.Models.Utilizador;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Regista serviços no contêiner
RegisterServices(builder);

var app = builder.Build();

// Configura o pipeline de requisição HTTP
ConfigureHttpPipeline(app);

// Executa ações de inicialização
await InitializeData(app);

app.Run();

// Método para registar os serviços
void RegisterServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
    {
        build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

    builder.Services.AddDbContext<StoreContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddIdentityServices(builder.Configuration);
    builder.Services.AddIdentity<AppUser, IdentityRole>()
        .AddEntityFrameworkStores<AppIdentityDbContext>()
        .AddDefaultTokenProviders();
    builder.Services.AddScoped<IBasketRepository, BasketRepository>();
    builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
    builder.Services.AddScoped<ITokenService, TokenService>(); 
    builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
        options.AddPolicy("GestorLoja", policy => policy.RequireRole("GestorLoja"));
    });
}

// Método para configurar o pipeline de requisição HTTP
void ConfigureHttpPipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseCors("corspolicy");
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
}

// Método para executar ações de inicialização
async Task InitializeData(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        await context.Database.MigrateAsync();
        await identityContext.Database.MigrateAsync();
        await StoreContextSeed.SeedAsync(context);
        await AppIdentityDbContextSeed.SeedRolesAsync(roleManager);
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Surgiu um problema durante a migração");
    }
}