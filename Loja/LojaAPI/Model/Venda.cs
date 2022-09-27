using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaApi.Model;

[Table("Venda")]
public class Venda
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idVenda { get; set; }

    [Required]
    public DateTime DataVenda { get; set; }

    public virtual ICollection<VendaCarrinho> VendaCarrinho { get; set; }

}