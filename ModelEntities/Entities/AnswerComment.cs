/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Repr�sente un commentaire laiss� sur une question
/// </summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class AnswerComment
    {
        #region Properties
        /* membres de classe propres � l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QCommentID { get; set; }
        // repr�sente le contenu du commentaire
        public string Content { get; set; }

        [ForeignKey("LinkedAnswer")]
        public int AnswerID { get; set; }
        #endregion

        #region Associations
        // Un commentaire n'appartient qu'� une seule r�ponse
        [Required]
        public virtual Answer LinkedAnswer { get; set; }
        #endregion
    }
}
