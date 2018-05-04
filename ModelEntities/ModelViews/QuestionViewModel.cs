using System.ComponentModel.DataAnnotations;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
    public class QuestionViewModel
    {
        [Display(Name = "ID Question : ")]
        public int QuestionID { get; set; }

        [Required]
        [Display(Name = "Libellé : ")]
        public string Libelle { get; set; }

        [Required]
        [Display(Name = "Actif : ")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Type de Question : ")]
        public virtual QuestionType LinkedQType { get; set; }

        [Required]
        [Display(Name = "Difficulté : ")]
        public virtual Difficulty LinkedDifficulty { get; set; }

        [Required]
        [Display(Name = "Technologie : ")]
        public virtual Techno LinkedTechno { get; set; }

    }
}
