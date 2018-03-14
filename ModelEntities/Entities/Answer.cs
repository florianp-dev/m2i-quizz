/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les réponses possibles à une question
/// </summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    class Answer
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }

        /* membres de classe liés à la cardinalité des objets */
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        #endregion

        #region Associations
        // Réponse a une Question
        public virtual Question LinkedQuestion { get; set; }
        // Réponse peut avoir une réponseQuiz
        //public virtual ReponseQuizz LinkedReponseQuizz { get; set; }
        #endregion
    }
}
