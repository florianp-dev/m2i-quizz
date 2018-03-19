/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Repr�sente un quizz dans l'application
/// </summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Quizz
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizzID { get; set; }
        public string CandidateFirstname { get; set; }
        public string CandidateLastname { get; set; }
        #endregion

        #region Associations
        public virtual Difficulty Difficulty { get; set; }
        public virtual Result LinkedResult { get; set; }
        #endregion
    }
}
