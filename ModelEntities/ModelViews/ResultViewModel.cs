using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
    public class ResultViewModel
    {
        [Required]
        [Display(Name = "Résultat : ")]
        public int ResultID { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
