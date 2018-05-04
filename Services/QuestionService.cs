using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;
using ModelEntities.ModelViews;

namespace Services
{
    public class QuestionService
    {
        public List<Question> GetAllQuestions()
        {
            var questionViewModel = new List<Question>();
            using (var dbContext = new DataBaseContext())
            {
                var questionEntities = dbContext.Questions.ToList();
                foreach (var questionEntity in questionEntities)
                {
                    questionViewModel.Add(questionEntity);
                }
            }
            return questionViewModel;
        }

        public List<QuestionApiViewModel> GetAllQuestionsApi()
        {
            var questionViewModel = new List<QuestionApiViewModel>();
            using (var dbContext = new DataBaseContext())
            {
                var questionEntities = dbContext.Questions.ToList();
                foreach (var questionEntity in questionEntities)
                {
                    questionViewModel.Add(questionEntity.MapToQuestionsApiViewModel());
                }
            }
            return questionViewModel;
        }

        public Question GetById(int id)
        {
            Question q = new Question();
            using (var db = new DataBaseContext())
            {
                q = db.Questions.Find(id);
            }
            return q;
        }

        public void Remove(int id)
        {
            using (var db = new DataBaseContext())
            {
                var q = db.Questions.Find(id);
                db.Questions.Remove(q);
                db.SaveChanges();
            }
        }
    }
}
