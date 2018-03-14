/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Repr�sente un commentaire laiss� sur une question
/// </summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities
{
    class CommentaireQuestion
    {
        #region Properties
        /* membres de classe propres � l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        // repr�sente le contenu du commentaire
        public string Commentaire { get; set; }
        // Un commentaire n'appartient qu'� une seule question
        public Question Question { get; set; }
        #endregion
    }
}
