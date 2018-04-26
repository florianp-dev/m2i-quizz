using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    class PercentViewModel
    {
        [Display(Name = "ID Pourcentage : ")]
        public int PercentID { get; set; }

        [Required]
        [Display(Name = "Débutant : ")]
        public decimal Beginner { get; set; }

        [Required]
        [Display(Name = "Intermédiaire : ")]
        public decimal Intermediate { get; set; }

        [Required]
        [Display(Name = "Expert : ")]
        public decimal Expert { get; set; }
    }
}
