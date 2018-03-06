namespace ModelEntities
{
    public class ReponseQuizz
    {
        #region Attributs
        /* membres de classe propres � l'objet */
        private string _value;

        /* membres de classe li�s � la cardinalit� des objets */
        private Quizz _quiz;
        private Reponse _answer;
        #endregion

        #region Getters/Setters
        public string Value { get; set; }
        public Quizz Quiz { get; set; }
        public Reponse Answer { get; set; }
        #endregion

        #region Constructors
        public ReponseQuizz(string pValue, Quizz pQuiz, Reponse pAnswer)
        {
            _value = pValue;
            _quiz = pQuiz;
            _answer = pAnswer;
        }
        #endregion
    }
}
