using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    /// <remarks>
    /// La master difficulty doit enregistrer les taux dans percent selon le niveau
    /// </remarks>
    public class Difficulty
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyID { get; set; }
        public string Wording { get; set; }

       [ForeignKey("Percent")]
       public int PercentID { get; set; }
        #endregion

        #region Associations
        public virtual Percent Percent { get; set; }
        public virtual List<Quizz> LinkedQuizz { get; set; }
        #endregion
    }
}
