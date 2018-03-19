/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les difficultés possibles
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Difficulty
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyID { get; set; }
        public string Wording { get; set; }
        /// <summary>
        /// Donne le pourcentage de questions de cette difficulté à incorporer à un quizz
        /// </summary>
        public int Percentage { get; set; }
        #endregion

        #region Associations
        public virtual ICollection<Quizz> LinkedQuizz { get; set; }
        public virtual ICollection<Question> LinkedQuestion { get; set; }
        #endregion
    }
}
