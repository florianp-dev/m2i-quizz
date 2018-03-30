/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente un commentaire laissé sur une question
/// </summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class AnswerComment
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QCommentID { get; set; }
        // représente le contenu du commentaire
        public string Content { get; set; }

        [ForeignKey("LinkedAnswer")]
        public int AnswerID { get; set; }
        #endregion

        #region Associations
        // Un commentaire n'appartient qu'à une seule réponse
        [Required]
        public virtual Answer LinkedAnswer { get; set; }
        #endregion
    }
}
