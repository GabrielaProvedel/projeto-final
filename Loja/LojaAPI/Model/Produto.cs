using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Model;

[Table("Produto")]
public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProduto { get; set; }
    
    public virtual TipoProduto TipoProduto { get; set; }

    [Required]
    [MaxLength(30)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(30)]
    public string Marca { get; set; }

    [Required]
    public double Preco { get; set; }
    
    [Required]
    public int Estoque { get; set; }

}