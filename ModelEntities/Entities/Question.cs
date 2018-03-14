/// <remarks>
/// Florian POUCHELET
/// </remarks>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities
{
    public class Question
    {
        #region Properties
        /* Constante du nombre de réponses possibles */
        private static int MAX_REPONSE = 4;

        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public string Libelle { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region Associations
        /* membres de classe liés à la cardinalité des objets */
        // Une Question a une seule techno
        public virtual Techno Techno { get; set; }
        // Une question a entre 0 et 4 réponses
        public virtual Reponse[] LinkedResponse { get; set; }
        // Une question peut avoir plusieurs QuestionQuizz
        public virtual ICollection<QuestionQuizz> LinkedQuestionQuizz { get; set; }
        // Une question a au plus un commentaire
        public virtual CommentaireQuestion LinkedCommentaireQuestion { get; set; }
        #endregion

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
    }
}
