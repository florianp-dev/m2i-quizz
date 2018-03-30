using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.Entities
{
    public class ResultAnswer
    {
        #region Properties
        /* membres de classe propres à l'objet */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultAnswerID { get; set; }
        #endregion

        #region Associations
        [Required]
        public virtual List<Result> LinkedResult { get; set; }
        public virtual List<Answer> LinkedAnswers { get; set; }
        #endregion
    }
}
