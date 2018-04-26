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
        #endregion

        #region Associations
        public virtual List<Question> LinkedQuestion { get; set; }
        #endregion
    }
}
