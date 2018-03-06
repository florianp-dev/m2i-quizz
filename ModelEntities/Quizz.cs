using System.Collections.Generic;

namespace ModelEntities
{
    public class Quizz
    {
        #region Attributs
        private int _id;
        private string _surname;
        private string _firstname;
        private int _idCandidate;
        private List <QuestionQuizz> _questionQuiz;
        private CommentaireQuestion _questionComment;
        private List <ReponseQuizz> _quizAnswer;
        #endregion

        #region Getters/Setters
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int IdCandidate { get; set; }
        public List<QuestionQuizz> QuestionQuiz { get; set; }
        public CommentaireQuestion QuestionComment { get; set; }
        public List<ReponseQuizz> QuizAnswer { get; set; }
        #endregion

        #region Constructors
        public Quizz(int pId, string pSurname, string pFirstname, int pIdCandidate, List<QuestionQuiz> pQuestionQuiz, QuestionComment pQuestionComment, List<QuizAnswer> pQuizAnswer)
        {
            _id = pId;
            _surname = pSurname;
            _firstname = pFirstname;
            _idCandidate = pIdCandidate;
            _questionComment = pQuestionComment;
        }
        #endregion


    }
}
