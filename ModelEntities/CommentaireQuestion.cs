using System.Collections.Generic;

namespace ModelEntities
{
    public class CommentaireQuestion
    {
        #region Getters/Setters
        public string Commentaire { get; set; }
        public List<Quizz> Quiz { get; set; }
        public Question Question { get; set; }
        #endregion

        #region Constructeurs
        public CommentaireQuestion(string pCommentaire, Question pQuestion)
        {
            Commentaire = pCommentaire;
            Question = pQuestion;
        }
        #endregion
    }
}
