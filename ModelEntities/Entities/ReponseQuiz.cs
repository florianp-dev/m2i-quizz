
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <remarks>
/// Florian POUCHELET
/// </remarks>
namespace ModelEntities
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
        public virtual Reponse Answer { get; set; }
        #endregion
    }
}
