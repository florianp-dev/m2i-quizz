using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelEntities.ModelViews
{
    public class QuizzViewModel
    {
        [Display(Name = "ID Quizz : ")]
        public int QuizzID { get; set; }

        [Required]
        [Display(Name = "Technologie : ")]
        public int TechnoID;

        [Required]
        [Display(Name = "Difficulté : ")]
        public int DifficultyID;

        [Required]
        [Display(Name = "Nombre de questions : ")]
        public int NbQuestions;

        [Required]
        [Display(Name = "Prénom Candidat : ")]
        public string CandidateFirstname { get; set; }

        [Required]
        [Display(Name = "Nom Candidat : ")]
        public string CandidateLastname { get; set; }
    }
}
