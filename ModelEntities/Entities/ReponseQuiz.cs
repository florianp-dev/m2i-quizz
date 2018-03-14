/// <remarks>
/// Florian POUCHELET
/// </remarks>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    class ReponseQuizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RQuizzID { get; set; }
        public string Value { get; set; }
        #endregion

        #region Associations
        public virtual Quizz Quizz { get; set; }
        public virtual Answer Answer { get; set; }
        #endregion
    }
}
