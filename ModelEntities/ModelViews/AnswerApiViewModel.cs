using System.ComponentModel.DataAnnotations;

namespace ModelEntities.ModelViews
{
    public class AnswerApiViewModel
    {
        public int QuestionID { get; set; }

        [Display(Name = "ID Réponse : ")]
        public int AnswerID { get; set; }

        [Required]
        [Display(Name = "Réponse : ")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Est correcte: ")]
        public bool IsCorrect { get; set; }
    }
}
