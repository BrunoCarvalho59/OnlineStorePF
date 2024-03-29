﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Models.Basket.BasketCliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("lastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BasketsCliente");
                });

            modelBuilder.Entity("Core.Models.Basket.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BasketClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProdutoNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasketClienteId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("Core.Models.Baskets", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BasketData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Core.Models.Compras.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClienteEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CompraData")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MetodoEnvioId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MetodoEnvioId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Core.Models.Compras.CompraItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompraId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.ToTable("CompraItems");
                });

            modelBuilder.Entity("Core.Models.Compras.MetodoEnvio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TempoEnvio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MetodosEnvio");
                });

            modelBuilder.Entity("Core.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdutoCategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoMarcaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoCategoriaId");

                    b.HasIndex("ProdutoMarcaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Core.Models.ProdutoCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Core.Models.ProdutoMarca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Core.Models.Basket.BasketItem", b =>
                {
                    b.HasOne("Core.Models.Basket.BasketCliente", null)
                        .WithMany("Items")
                        .HasForeignKey("BasketClienteId");
                });

            modelBuilder.Entity("Core.Models.Compras.Compra", b =>
                {
                    b.HasOne("Core.Models.Compras.MetodoEnvio", "MetodoEnvio")
                        .WithMany()
                        .HasForeignKey("MetodoEnvioId");

                    b.OwnsOne("Core.Models.Compras.Morada", "MoradaEnvio", b1 =>
                        {
                            b1.Property<int>("CompraId")
                                .HasColumnType("int");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Localidade")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PrimeiroNome")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Rua")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("UltimoNome")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Zip")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CompraId");

                            b1.ToTable("Compras");

                            b1.WithOwner()
                                .HasForeignKey("CompraId");
                        });

                    b.Navigation("MetodoEnvio");

                    b.Navigation("MoradaEnvio")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Models.Compras.CompraItem", b =>
                {
                    b.HasOne("Core.Models.Compras.Compra", null)
                        .WithMany("CompraItems")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Core.Models.Compras.ProdutoItemCompra", "ItemPedido", b1 =>
                        {
                            b1.Property<int>("CompraItemId")
                                .HasColumnType("int");

                            b1.Property<string>("FotoUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("ProdutoItemId")
                                .HasColumnType("int");

                            b1.Property<string>("ProdutoNome")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CompraItemId");

                            b1.ToTable("CompraItems");

                            b1.WithOwner()
                                .HasForeignKey("CompraItemId");
                        });

                    b.Navigation("ItemPedido");
                });

            modelBuilder.Entity("Core.Models.Produto", b =>
                {
                    b.HasOne("Core.Models.ProdutoCategoria", "ProdutoCategoria")
                        .WithMany()
                        .HasForeignKey("ProdutoCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.ProdutoMarca", "ProdutoMarca")
                        .WithMany()
                        .HasForeignKey("ProdutoMarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoCategoria");

                    b.Navigation("ProdutoMarca");
                });

            modelBuilder.Entity("Core.Models.Basket.BasketCliente", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Core.Models.Compras.Compra", b =>
                {
                    b.Navigation("CompraItems");
                });
#pragma warning restore 612, 618
        }
    }
}
