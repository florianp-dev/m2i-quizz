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
        public string Wording { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("LinkedTechno")]
        public int TechnoID { get; set; }
        [ForeignKey("LinkedQType")]
        public int QTypeID { get; set; }
        [ForeignKey("LinkedDifficulty")]
        public int DifficultyID { get; set; }
        #endregion

        #region Associations
        // Une Question a une seule techno
        public virtual Techno LinkedTechno { get; set; }
        // Une question à un type de question
        public virtual QuestionType LinkedQType { get; set; }
        // Une question n'a qu'une seule difficulté
        public virtual Difficulty LinkedDifficulty { get; set; }
        // Une question a entre 0 et 4 réponses
        public virtual List<Answer> LinkedResponse { get; set; }
        #endregion
    }
}
