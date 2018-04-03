using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Percent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PercentID { get; set; }

        public decimal Beginner { get; set; }
        public decimal Intermediate { get; set; }
        public decimal Expert { get; set; }
    }
}
