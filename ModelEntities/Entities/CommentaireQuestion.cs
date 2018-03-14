/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente un commentaire laissé sur une question
/// </summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities
{
    class CommentaireQuestion
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentID { get; set; }
        // représente le contenu du commentaire
        public string Commentaire { get; set; }
        // Un commentaire n'appartient qu'à une seule question
        public Question Question { get; set; }
        #endregion
    }
}
