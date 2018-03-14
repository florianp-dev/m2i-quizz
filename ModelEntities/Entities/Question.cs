/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente une question dans le Quizz
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities
{
    class Question
    {
        #region Properties
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
        // Une question à un type de question
        public virtual QuestionType QType { get; set; }
        // Une question a entre 0 et 4 réponses
        public virtual Reponse[] LinkedResponse { get; set; }
        // Une question peut avoir plusieurs QuestionQuizz
        public virtual ICollection<QuestionQuizz> LinkedQuestionQuizz { get; set; }
        // Une question a au plus un commentaire
        public virtual CommentaireQuestion LinkedCommentaireQuestion { get; set; }
        #endregion
    }
}
