/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente une question dans le Quizz
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Question
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public string Libelle { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region Associations
        // Une Question a une seule techno
        public virtual Techno Techno { get; set; }
        // Une question à un type de question
        public virtual QuestionType QType { get; set; }
        // Une question n'a qu'une seule difficulté
        public virtual Difficulty Difficulty { get; set; }
        // Une question a entre 0 et 4 réponses
        public virtual ICollection<Answer> LinkedResponse { get; set; }
        // Une question a au plus un commentaire
        public virtual QuestionComment LinkedQuestionComment { get; set; }
        #endregion
    }
}
