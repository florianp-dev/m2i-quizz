/// <remarks>
/// Florian POUCHELET
/// </remarks>

using System;
using System.Collections.Generic;

namespace ModelEntities
{
    public class Question
    {
        /* Constante du nombre de réponses possibles */
        private static int MAX_REPONSE = 4;

        /* membres de classe propres à l'objet */
        private int _questionID;
        public string Libelle { get; set; }
        public bool IsActive { get; set; }

        /* membres de classe liés à la cardinalité des objets */
        // Une Question a une seule techno
        public Techno Techno { get; set; }
        // Une question a entre 0 et 4 réponses
        public Reponse[] LinkedResponse { get; set; }
        // Une question peut avoir plusieurs QuestionQuizz
        public List<QuestionQuizz> LinkedQuestionQuizz { get; set; }
        // Une question a au plus un commentaire
        public CommentaireQuestion LinkedCommentaireQuestion { get; set; }

        public Question(string pLib, Techno pTech)
        {
            Libelle = pLib;
            Techno = pTech;
            IsActive = true;
            LinkedResponse = new Reponse[MAX_REPONSE];
            LinkedQuestionQuizz = new List<QuestionQuizz>();
            LinkedCommentaireQuestion = null;
        }

        public Question(string pLib, Techno pTech, Reponse[] pRep): this(pLib, pTech)
        {
            LinkedResponse = pRep;
        }

        public Question(string pLib, Techno pTech, List<QuestionQuizz> pQQ) : this(pLib, pTech)
        {
            LinkedQuestionQuizz = pQQ;
        }

        public Question(string pLib, Techno pTech, Reponse[] pRep, List<QuestionQuizz> pQQ) : this(pLib, pTech, pRep)
        {
            LinkedQuestionQuizz = pQQ;
        }

        /// <summary>
        /// Ajoute un commentaire à la question
        /// </summary>
        /// <param name="pCom">Le commentaire à ajouter</param>
        public void AddComment(string pCom)
        {
            if (LinkedCommentaireQuestion != null)
                throw new InvalidOperationException("Un commentaire a déjà été attaché à cette question");

            LinkedCommentaireQuestion = new CommentaireQuestion(pCom, this);
        }
    }
}
