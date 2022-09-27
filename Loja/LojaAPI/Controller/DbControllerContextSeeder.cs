using System;
using LojaApi.Model;

namespace LojaApi.Controller;

public static class DbControllerContextSeeder {

    public static void Seed(DbControllerContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Tipo Produto
        context.TiposProdutos.Add(new TipoProduto() { NomeTipoProduto = "Higiene" });
        context.TiposProdutos.Add(new TipoProduto() { NomeTipoProduto = "Limpeza" });
        context.TiposProdutos.Add(new TipoProduto() { NomeTipoProduto = "Bebidas" });
        context.TiposProdutos.Add(new TipoProduto() { NomeTipoProduto = "Hortifruti" });
        context.TiposProdutos.Add(new TipoProduto() { NomeTipoProduto = "Padaria" });

        // Produto
        context.Produtos.Add(new Produto() {
            Nome = "Sabonete", 
            Estoque = 200, 
            Marca = "Dove",
            Preco = 2.0,
            TipoProduto = context.TiposProdutos.Local.Single(tp => tp.NomeTipoProduto == "Higiene")
        });
        context.Produtos.Add(new Produto() {
            Nome = "Shampoo",
            Estoque = 20,
            Marca = "Johnson & Johnson",
            Preco = 16.5,
            TipoProduto = context.TiposProdutos.Local.Single(tp => tp.NomeTipoProduto == "Higiene")
        });
        context.Produtos.Add(new Produto() {
            Nome = "Detergente",
            Estoque = 10,
            Marca = "Ypê",
            Preco = 5.4,
            TipoProduto = context.TiposProdutos.Local.Single(tp => tp.NomeTipoProduto == "Limpeza")
        });

        context.SaveChanges();
    }

}