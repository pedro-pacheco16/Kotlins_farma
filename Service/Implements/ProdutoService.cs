﻿using kotlins.Data;
using kotlins.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace kotlins.Service.Implements
{
    public class ProdutoService : IProdutoService
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
               .ToListAsync();
        }

        public async Task<Produto?> GetById(long id)
        {
            try
            {
                var Resposta = await _context.Produtos
                    .FirstAsync(i => i.id == id);

                return Resposta;
            }
            catch
            {
                return null;
            };
        }
        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produto = await _context.Produtos
              .Where(p => p.Nome.Contains(nome))
              .ToListAsync();

            return Produto;
        }

        public async Task<IEnumerable<Produto>> GetByPreco(decimal preco)
        {
               var produto = await _context.Produtos
               .Where(p => p.Preco == preco)
               .ToListAsync();

                return produto;
        }

        public async Task<IEnumerable<Produto>> GetByMarca(string marca)
        {
            {
               var Produto = await _context.Produtos
             
              .Where(p => p.Marca.Contains(marca))
              .ToListAsync();

                return Produto;
            };
        }

        
        public async Task<Produto?> Create(Produto produto)
        {

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;

        }

        public async Task<Produto?> Update(Produto produto)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(produto.id);

            if (ProdutoUpdate is null)
                return null;

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;

            _context.Entry(produto).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}
