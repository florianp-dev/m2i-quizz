﻿using System.ComponentModel.DataAnnotations;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
    public class AnswerViewModel
    {
        
        [Display(Name = "ID Réponse : ")]
        public int AnswerID { get; set; }

        [Required]
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
