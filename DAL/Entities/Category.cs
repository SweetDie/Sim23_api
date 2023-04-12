using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("tblCategories")]
    public class Category : BaseEntity<int>
    { 
        [Required, StringLength(255)]
        public string Name { get; set; }
    }
}
