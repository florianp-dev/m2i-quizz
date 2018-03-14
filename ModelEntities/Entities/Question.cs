/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente une question dans le Quizz
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
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

        /* membres de classe liés à la cardinalité des objets */
        [ForeignKey("Techno")]
        public int TechnoID { get; set; }
        [ForeignKey("QuestionType")]
        public int QTypeID { get; set; }
        [ForeignKey("Answer")]
        public int AnswerID { get; set; }
        [ForeignKey("QuestionComment")]
        public int QCommentID { get; set; }
        #endregion

        #region Associations
        // Une Question a une seule techno
        public virtual Techno Techno { get; set; }
        // Une question à un type de question
        public virtual QuestionType QType { get; set; }
        // Une question a entre 0 et 4 réponses
        public virtual Answer[] LinkedResponse { get; set; }
        // Une question peut avoir plusieurs QuestionQuizz
        //public virtual ICollection<QuestionQuizz> LinkedQuestionQuizz { get; set; }
        // Une question a au plus un commentaire
        public virtual QuestionComment LinkedCommentaireQuestion { get; set; }
        #endregion
    }
}
