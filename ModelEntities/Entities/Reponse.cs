
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les réponses possible à une question
/// </summary>
namespace ModelEntities
{
    class Reponse
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReponseID { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        #endregion

        #region Associations
        /* membres de classe liés à la cardinalité des objets */
        // Réponse a une Question
        public virtual Question LinkedQuestion { get; set; }
        // Réponse peut avoir une réponseQuiz
        public virtual ReponseQuizz LinkedReponseQuiz { get; set; }
        #endregion
    }
}
