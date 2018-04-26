using System.ComponentModel.DataAnnotations;

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
