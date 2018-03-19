﻿/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les types de question possibles
/// (ex: technique, ouverte, etc)
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    class QuestionType
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QTypeID { get; set; }
        public string Wording { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        #endregion

        #region Associations
        // Un type de question a plusieurs questions
        public virtual ICollection<Question> LinkedQuestions { get; set; }
        #endregion
    }
}
