using System.ComponentModel.DataAnnotations;

namespace ModelEntities.ModelViews
{
    public class QuestionApiViewModel
    {
        [Display(Name = "ID Question : ")]
        public int QuestionID { get; set; }

        [Required]
        [Display(Name = "Libellé : ")]
        public string Libelle { get; set; }

        [Required]
        [Display(Name = "Actif : ")]
        public bool IsActive { get; set; }
    }
}
