using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities
{
    class Quizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizzID { get; set; }
        public string CandidateFirstname { get; set; }
        public string CandidateLastname { get; set; }
        #endregion

        #region Associations
        public virtual List<QuestionQuizz> QuestionQuiz { get; set; }
        public virtual CommentaireQuestion QuestionComment { get; set; }
        public virtual List<ReponseQuizz> QuizAnswer { get; set; }
        #endregion
    }
}
