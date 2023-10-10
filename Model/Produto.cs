using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kotlins.Model
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Marca { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "Decimal(6,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5000)]
        public string Foto { get; set; } = string.Empty;
    }
}
