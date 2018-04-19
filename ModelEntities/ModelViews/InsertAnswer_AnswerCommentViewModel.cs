using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
   public class InsertAnswer_AnswerCommentViewModel
    {
        //comment
        public int QCommentID { get; set; }
        public string QContent { get; set; }

        //Answers
        public int AnswerID { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
    }
}
