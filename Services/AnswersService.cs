using System.Collections.Generic;
using System.Linq;
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

        public List<AnswerApiViewModel> GetAnswerByQuestionId(int id)
        {
            var answerViewModel = new List<AnswerApiViewModel>();
            using (var dbContext = new DataBaseContext())
            {
                var answerEntities = dbContext.Answers.Where(a => a.QuestionID == id).ToList();
                foreach (var answerEntity in answerEntities)
                {
                    answerViewModel.Add(answerEntity.MapToAnswerApiViewModel());
                }
            }
            return answerViewModel;
        }
    }
}
