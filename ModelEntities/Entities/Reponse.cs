/// <remarks>
/// Florian POUCHELET
/// </remarks>

namespace ModelEntities
{
    public class Reponse
    {
        /* membres de classe propres à l'objet */
        private int _reponseID;
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        /* membres de classe liés à la cardinalité des objets */
        // Réponse a une Question
        public Question LinkedQuestion { get; set; }
        // Réponse peut avoir une réponseQuiz
        public ReponseQuizz LinkedReponseQuiz { get; set; }

        public Reponse(string pContent, bool pIsCorrect, Question pQuestion)
        {
            Content = pContent;
            LinkedQuestion = pQuestion;
            IsCorrect = pIsCorrect;
        }
    }
}
