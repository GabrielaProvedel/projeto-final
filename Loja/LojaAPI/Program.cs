using System;
using Microsoft.EntityFrameworkCore;
using LojaApi.Controller;
using LojaApi.Model;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new DbControllerContext();
        DbControllerContextSeeder.Seed(context);
        Console.WriteLine("Exemplo Code-First");
        Console.WriteLine();

        var query = context.Produtos
            .Include(p => p.TipoProduto)
            .Where(p => p.Preco > 1)
            .ToList();
        
        Console.WriteLine("{0,-10} | {1,-15} | {2}", "Nome", "TipoProduto", "Preço"); 
        Console.WriteLine(); 
        foreach (var product in query)
            Console.WriteLine("{0,-10} | {1,-15} | {2}", product.Nome, product.TipoProduto.NomeTipoProduto, product.Preco); 

        

        Console.ReadKey();
    }
}