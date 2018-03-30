using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    class QuestionViewModel
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
