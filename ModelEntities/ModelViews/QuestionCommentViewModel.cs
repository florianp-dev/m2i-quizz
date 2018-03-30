using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    class QuestionCommentViewModel
    {
       
        [Display(Name = " ID Commentaire : ")]
        public int QCommentID { get; set; }

        [Required]
        [Display(Name = "Contenu : ")]
        public string Content { get; set; }
    }
}
