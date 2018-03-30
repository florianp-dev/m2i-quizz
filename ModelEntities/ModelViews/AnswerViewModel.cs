using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    class AnswerViewModel
    {
        
        [Display(Name = "ID Réponse : ")]
        public int AnswerID { get; set; }

        [Required]
        [Display(Name = "Contenu : ")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Correction : ")]
        public bool IsCorrect { get; set; }
    }
}
