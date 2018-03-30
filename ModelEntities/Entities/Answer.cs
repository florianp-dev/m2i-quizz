/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les réponses possibles à une question
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Answer
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey("LinkedQuestion")]
        public int QuestionID { get; set; }
        [ForeignKey("LinkedResultAnswers")]
        public int ResultAnswerID { get; set; }
        #endregion

        #region Associations
        // Réponse a une Question
        public virtual Question LinkedQuestion { get; set; }
        // Une réponse appartient à plusieurs résultats
        public virtual ResultAnswer LinkedResultAnswers { get; set; }
        #endregion
    }
}
