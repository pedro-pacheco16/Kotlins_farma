﻿using kotlins.Model;
using Microsoft.EntityFrameworkCore;

namespace kotlins.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produto");

            modelBuilder.Entity<Categoria>().ToTable("tb_categoria");

            _ = modelBuilder.Entity<Produto>()
               .HasOne(_ => _.Categoria)
               .WithMany(c => c.produto)
               .HasForeignKey("CategoriaId")
               .OnDelete(DeleteBehavior.Cascade);
        }

        // Registrar DbSet - Objeto responsável por manipular a Tabela

        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
    }
}