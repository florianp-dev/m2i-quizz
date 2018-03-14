namespace ModelEntities
{
    public class ReponseQuizz
    {
        #region Properties
        public string Value { get; set; }
        public Quizz Quizz { get; set; }
        public Reponse Answer { get; set; }
        #endregion

        public ReponseQuizz(string pValue, Quizz pQuiz, Reponse pAnswer)
        {
            Value = pValue;
            Quizz = pQuiz;
            Answer = pAnswer;
        }
    }
}
