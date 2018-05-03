using System.Linq;
using System.Web.Security;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
     public static class Map
    {
        public static QuizzViewModel MapToQuizzViewModel(this Quizz quizz)
        {
            if (quizz == null)
                return new QuizzViewModel();

            var technoName = "";
            var difficultyName = "";

            using (var db = new DataBaseContext())
            {
                technoName = db.Technos.Find(quizz.TechnoID).Wording;
                difficultyName = db.Difficulties.Find(quizz.DifficultyID).Wording;
            }

            return new QuizzViewModel
            {
                QuizzID = quizz.QuizzID,
                CandidateFirstname = quizz.CandidateFirstname,
                CandidateLastname = quizz.CandidateLastname,
                TechnoName = technoName,
                DifficultyName = difficultyName,
                TechnoID = quizz.TechnoID,
                DifficultyID = quizz.DifficultyID,
                NbQuestions = quizz.NbQuestions
            };
        }

        public static DifficultyViewModel MapTomDifficultyViewModel(this Difficulty difficulty)
        {
            var difficultyViewModel = new DifficultyViewModel();

            if (difficulty == null)
            {
                return difficultyViewModel;
            }
            difficultyViewModel = new DifficultyViewModel()
            {
                DifficultyID = difficulty.DifficultyID,
                Wording = difficulty.Wording,
            };
            return difficultyViewModel;
        }

        public static DifficultyViewModel MapToDifficultyViewModel(this Difficulty difficulty)
        {
            var difficultyViewModel = new DifficultyViewModel();
        
            if (difficulty == null)
            {
                return difficultyViewModel;
            }
            difficultyViewModel = new DifficultyViewModel()
            {
                DifficultyID = difficulty.DifficultyID,
                Wording = difficulty.Wording,
                PercentID = difficulty.Percent.PercentID,
            };
            return difficultyViewModel;
        }

        public static UserViewModel MapToUserViewModel(this User user)
        {
            var userViewModel = new UserViewModel();

            if (user == null)
            {
                return userViewModel;
            }
            
            var isAdmin = Roles.IsUserInRole(user.UserName, "Admin");

            userViewModel = new UserViewModel()
            {
                UserID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName, 
                Tel = user.PhoneNumber,
                EmailAddress = user.Email,
                Society = user.Society,
                IsAdmin = isAdmin
            };
            return userViewModel;
        }

        public static QuestionViewModel MapToQuestionsViewModel(this Question question)
        {
            var questionViewModel = new QuestionViewModel();

            if (question == null)
            {
                return questionViewModel;
            }
            questionViewModel = new QuestionViewModel()
            {
                QuestionID = question.QuestionID,
                Libelle = question.Wording,
                IsActive = question.IsActive,
                LinkedQType = question.LinkedQType,
                LinkedDifficulty = question.LinkedDifficulty,
                LinkedTechno = question.LinkedTechno
            };
            return questionViewModel;
        }

        public static QuestionApiViewModel MapToQuestionsApiViewModel(this Question question)
        {
            var questionViewModel = new QuestionApiViewModel();

            if (question == null)
            {
                return questionViewModel;
            }
            questionViewModel = new QuestionApiViewModel()
            {
                QuestionID = question.QuestionID,
                Libelle = question.Wording,
                IsActive = question.IsActive
            };
            return questionViewModel;
        }


        public static AnswerViewModel MapToAnswerViewModel(this Answer answer)
        {
            var answerViewModel = new AnswerViewModel();

            if (answer == null)
            {
                return answerViewModel;
            }
           answerViewModel = new AnswerViewModel()
            {
                AnswerID = answer.AnswerID,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect,
                LinkedQuestion = answer.LinkedQuestion,
                LinkedAnswerComment = answer.LinkedComment
            };
            return answerViewModel;
        }
    }
}
