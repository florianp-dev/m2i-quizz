/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente le résultat à un quizz
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Result
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultID { get; set; }

        [ForeignKey("LinkedQuizz")]
        public int QuizzID { get; set; }
        [ForeignKey("LinkedResultAnswers")]
        public int ResultAnswerID { get; set; }
        #endregion

        #region Associations
        [Required]
        public virtual Quizz LinkedQuizz { get; set; }
        public virtual ResultAnswer LinkedResultAnswers { get; set; }
        #endregion
    }
}