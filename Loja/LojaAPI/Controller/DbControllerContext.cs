using Microsoft.EntityFrameworkCore;
using System;

using LojaApi.Model;

namespace LojaApi.Controller;

public class DbControllerContext : DbContext
{

    public DbSet<TipoProduto> TiposProdutos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<VendaCarrinho> VendaCarrinhos { get; set; }   
    public DbSet<Venda> Vendas { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(@"DataSource=loja.db;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    { }

    public void venda(List<(Produto, int)> produtos)
    {
        // Salva a venda
        this.Vendas.Add(new Venda() { 
            DataVenda = new DateTime()
        });
        this.SaveChanges();

        // Obtem Id da Venda
        int idVenda = this.Vendas.ToList<Venda>().Last<Venda>().idVenda;

        foreach(var item in produtos)
        {
            var produto = item.Item1;
            var qnt = item.Item2;
            
            // Venda Carrinho
            this.VendaCarrinhos.Add(new VendaCarrinho() { 
                IdVendaCarrinho = idVenda,
                Produto = produto,
                qntProduto = qnt
            });

            // Atualiza Estoque ou remove produto
            produto.Estoque -= qnt;
            if (produto.Estoque == 0)
                this.Produtos.Remove(produto);
            else
                this.Produtos.Update(produto);
        }

        this.SaveChanges();
    }

    public void relatorioPorProduto(string produto) 
    {
        // Função responsável por gerar o relatório por produto
    }

    public void relatorioPorData(DateTime data)
    {
        // Função responsável por gerar o relatório por data
    }

    public void relatorioDeVendas()
    {
        // Função responsável por gerar o relatório de vendas total
    }

}