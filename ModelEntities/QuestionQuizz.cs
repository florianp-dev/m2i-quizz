/// <remarks>
/// Florian POUCHELET
/// </remarks>

namespace ModelEntities
{
   public  class QuestionQuizz
    {
        /* membres de classe propres à l'objet */
        private int _questionQuizID;
        public int order { get; set; }

        /* membres de classe liés à la cardinalité des objets */
        // QuestionQuizz a un Quizz
        public Quizz LinkedQuizz { get; set; }
        // QuestionQuizz a une seule question
        public Question LinkedQuestion { get; set; }

        public QuestionQuizz(int pOrder, Quizz pQuizz, Question pQuest)
        {
            order = pOrder;
            LinkedQuizz = pQuizz;
            LinkedQuestion = pQuest;
        }
    }
}
