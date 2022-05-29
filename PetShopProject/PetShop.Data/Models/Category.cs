using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int CategoryId { get; set; }
        [StringLength(200)]
        public string? Name { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
