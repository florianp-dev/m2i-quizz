using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelEntities.ModelViews
{
    public class QuizzViewModel
    {
        [Required]
        [Display(Name = "ID Quizz : ")]
        public int QuizzID { get; set; }

        [Required]
        public int TechnoID;

        [Required]
        public int DifficultyID;

        [Display(Name = "Difficulté : ")]
        public string DifficultyName { get; set; }
        
        [Display(Name = "Technologie : ")]
        public string TechnoName { get; set; }

        [Required]
        [Display(Name = "Nombre de questions : ")]
        public int NbQuestions { get; set; }

        [Required]
        [Display(Name = "Prénom Candidat : ")]
        public string CandidateFirstname { get; set; }

        [Required]
        [Display(Name = "Nom Candidat : ")]
        public string CandidateLastname { get; set; }
    }
}
