using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Model;

[Table("VendaCarrinho")]
public class VendaCarrinho
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdVendaCarrinho { get; set; }
    
    public virtual Venda Venda { get; set; }

    public virtual Produto Produto { get; set; }
    
    [Required]
    public int qntProduto { get; set; }
    
}
