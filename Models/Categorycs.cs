using System.ComponentModel.DataAnnotations;

namespace HomeWorkOfProductAndCategory.Models
{
    public class Categorycs
    {
        [Key]
        public int Catid {  get; set; }
        public string? CatName { get; set; }
        //navigator product category
        public ICollection<Product>? Products { get; set; }
    }
}
