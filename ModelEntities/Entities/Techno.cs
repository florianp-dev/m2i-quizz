﻿/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les différentes technologies possibles
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    public class Techno
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnoID { get; set; }
        public string Wording { get; set; }
        #endregion

        #region Associations
        /* membres de classe liés à la cardinalité des objets */
        // Une techno peut avoir plusieurs questions
        public virtual List<Question> LinkedQuestions { get; set; }
        public virtual List<Quizz> LinkedQuizzes { get; set; }
        #endregion
    }
}
