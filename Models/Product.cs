using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWorkOfProductAndCategory.Models
{
    public class Product
    {
        public int ProductId {  get; set; }
        public string? ProName {  get; set; }

        [ForeignKey("Categoryid")]
        public Categorycs? Category { get; set; }

    }
}
