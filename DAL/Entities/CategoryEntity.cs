using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("tblCategories")]
    public class CategoryEntity : BaseEntity<int>
    { 
        [Required, StringLength(255)]
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Image { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
    }
}
