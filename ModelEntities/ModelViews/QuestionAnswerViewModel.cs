using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
    public class QuestionAnswerViewModel
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

        // réponse
        [Display(Name = "ID Réponse : ")]
        public int AnswerID { get; set; }

        [Display(Name = "Réponse : ")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Est correcte: ")]
        public bool IsCorrect { get; set; }

        [Required]
        [Display(Name = "La question: ")]
        public virtual Question LinkedQuestion { get; set; }

        [Display(Name = "Commentaire: ")]
        public virtual AnswerComment LinkedAnswerComment { get; set; }

    }
}
