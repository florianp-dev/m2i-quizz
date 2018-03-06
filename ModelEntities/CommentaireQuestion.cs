using System.Collections.Generic;

namespace ModelEntities
{
    public class CommentaireQuestion
    {
        #region Attributs
        private string _commentaire;
        private List<Quizz> _quiz;
        private Question _question;
        #endregion

        #region Getters/Setters
        public string Commentaire { get; set; }
        public List<Quizz> Quiz { get; set; }
        public Question Question { get; set; }
        #endregion

        #region Constructeurs
        public CommentaireQuestion(string pCommentaire, Question pQuestion)
        {
            _commentaire = pCommentaire;
            _question = pQuestion;
        }
        #endregion
    }
}
