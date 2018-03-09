namespace ModelEntities
{
    public class ReponseQuizz
    {
        #region Getters/Setters
        public string Value { get; set; }
        public Quizz Quizz { get; set; }
        public Reponse Answer { get; set; }
        #endregion

        #region Constructors
        public ReponseQuizz(string pValue, Quizz pQuiz, Reponse pAnswer)
        {
            Value = pValue;
            Quizz = pQuiz;
            Answer = pAnswer;
        }
        #endregion
    }
}
