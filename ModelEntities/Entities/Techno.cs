/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les différentes technologies possibles
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities
{
    class Techno
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechnoID { get; set; }
        public string Name { get; set; }
        #endregion

        #region Associations
        /* membres de classe liés à la cardinalité des objets */
        // Une techno peut avoir plusieurs questions
        public List<Question> LinkedQuestions { get; set; } = new List<Question>();
        #endregion
    }
}
