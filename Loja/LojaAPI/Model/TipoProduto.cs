using System;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Model;

[Table("TipoProduto")]
public class TipoProduto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTipoProduto { get; set; }

    [Required]
    [MaxLength(30)]
    public string NomeTipoProduto { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; }

}