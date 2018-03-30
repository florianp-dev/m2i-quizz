/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente un quizz dans l'application
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Quizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizzID { get; set; }
        public string CandidateFirstname { get; set; }
        public string CandidateLastname { get; set; }
        
        [ForeignKey("LinkedUser")]
        public int UserID { get; set; }
        [ForeignKey("LinkedTechno")]
        public int TechnoID { get; set; }
        [ForeignKey("LinkedDifficulty")]
        public int DifficultyID { get; set; }
        [ForeignKey("LinkedResult")]
        public int ResultID { get; set; }

        #endregion

        #region Associations
        public virtual User LinkedUser { get; set; }
        public virtual Techno LinkedTechno { get; set; }
        public virtual Difficulty LinkedDifficulty { get; set; }
        public virtual List<Question> LinkedQuestions { get; set; }
        public virtual Result LinkedResult { get; set; }
        #endregion
    }
}
