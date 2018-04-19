using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;
using ModelEntities.ModelViews;

namespace Services
{
    public class AnswersService
    {
        public List<AnswerViewModel> GetAllAnswers()
        {
            var answerViewModel = new List<AnswerViewModel>();
            using (var dbContext = new DataBaseContext())
            {
                var answerEntities = dbContext.Answers.ToList();
                foreach (var answerEntity in answerEntities)
                {
                    answerViewModel.Add(answerEntity.MapToAnswerViewModel());
                }
            }
            return answerViewModel;
        }
    }
}
