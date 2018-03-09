using System.Collections.Generic;

namespace ModelEntities
{
    public class Quizz
    {
        #region Getters/Setters
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public List<QuestionQuizz> QuestionQuiz { get; set; }
        public CommentaireQuestion QuestionComment { get; set; }
        public List<ReponseQuizz> QuizAnswer { get; set; }
        #endregion

        #region Constructors
        public Quizz(string pSurname, string pFirstname, List<QuestionQuizz> pQuestionQuiz, CommentaireQuestion pQuestionComment, List<ReponseQuizz> pQuizAnswer)
        {
            Surname = pSurname;
            Firstname = pFirstname;
            QuestionComment = pQuestionComment;
        }
        #endregion
    }
}
