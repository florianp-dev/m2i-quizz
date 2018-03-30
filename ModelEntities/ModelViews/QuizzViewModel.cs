using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    class QuizzViewModel
    {
        
        [Display(Name = "ID Quizz : ")]
        public int QuizzID { get; set; }

        [Required]
        [Display(Name = "Prénom Candidat : ")]
        public string CandidateFirstname { get; set; }

        [Required]
        [Display(Name = "Nom Candidat : ")]
        public string CandidateLastname { get; set; }
    }
}
