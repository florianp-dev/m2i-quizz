using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    public class MasterDifficultyViewModel
    {
        [Display(Name = "Master Difficulty ID : ")]
        public int MasterDifficultyID { get; set; }

        [Required]
        [Display(Name = "Libellé : ")]
        public string Wording { get; set; }

        [Required]
        [Display(Name = "Id Pourcentage : ")]
        public string PercentID { get; set; }

    }
}
