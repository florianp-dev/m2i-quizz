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
        public string libelle { get; set; }
        public bool IsActive { get; set; }

        /* membres de classe liés à la cardinalité des objets */
        // Une Question a une seule techno
        public Techno Techno { get; set; }
        // Une question a entre 0 et 4 réponses
        private Reponse[] _linkedReponses = new Reponse[MAX_REPONSE];
        public Reponse[] LinkedResponse { get { return _linkedReponses;  } }
        // Une question peut avoir plusieurs QuestionQuizz
        public List<QuestionQuizz> LinkedQuestionQuizz = new List<QuestionQuizz>();
        // Une question a au plus un commentaire
        public CommentaireQuestion LinkedCommentaireQuestion { get; set; } = null;

        public Question(string pLib, Techno pTech)
        {
            libelle = pLib;
            Techno = pTech;
            IsActive = true;
        }

        public Question(string pLib, Techno pTech, Reponse[] pRep): this(pLib, pTech)
        {
            _linkedReponses = pRep;
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
        /// Permet d'ajouter une réponse possible à la question
        /// Lève une exception si on ajoute trop de questions
        /// </summary>
        /// <param name="pRep">Réponse à ajouter</param>
        public void AddReponse(Reponse pRep)
        {
            var length = _linkedReponses.Length;

            if (length == MAX_REPONSE)
                throw new IndexOutOfRangeException("Il y a déjà le maximum de réponses possible pour cette question");

            _linkedReponses[length] = pRep;
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
