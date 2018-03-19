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
        #endregion

        #region Associations
        public virtual Quizz LinkedQuizz { get; set; }
        public virtual ICollection<Answer> LinkedAnswers { get; set; }
        #endregion
    }
}