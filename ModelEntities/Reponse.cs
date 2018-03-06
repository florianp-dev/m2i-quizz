/// <remarks>
/// Florian POUCHELET
/// </remarks>

namespace ModelEntities
{
    public class Reponse
    {
        /* membres de classe propres à l'objet */
        private int _reponseID;
        private string _content;
        private bool _isCorrect;
        public string Content { get { return _content; } }
        public bool IsCorrect { get { return _isCorrect; } }

        /* membres de classe liés à la cardinalité des objets */
        // Réponse a une Question
        private Question _linkedQuestion;
        public Question LinkedQuestion { get { return _linkedQuestion; } }
        // Réponse peut avoir une réponseQuiz
        public ReponseQuizz LinkedReponseQuiz { get; set; }

        public Reponse(string pContent, bool pIsCorrect, Question pQuestion)
        {
            _content = pContent;
            _linkedQuestion = pQuestion;
            _isCorrect = pIsCorrect;
        }
    }
}
