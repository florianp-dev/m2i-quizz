/// <remarks>
/// Florian POUCHELET
/// </remarks>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities
{
   class QuestionQuizz
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionQuizID { get; set; }
        #endregion

        #region Associations
        /* membres de classe liés à la cardinalité des objets */
        // QuestionQuizz a un Quizz
        public Quizz LinkedQuizz { get; set; }
        // QuestionQuizz a une seule question
        public Question LinkedQuestion { get; set; }
        #endregion
    }
}
