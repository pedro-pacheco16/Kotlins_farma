using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace kotlins.Model
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Tipo { get; set; } = string.Empty;

        [InverseProperty("Categoria")]
        [JsonIgnore]
        public virtual ICollection<Produto>? produto { get; set; }
    }
}
