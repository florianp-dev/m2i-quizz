using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
     public static class Map
    {
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
            };
            return difficultyViewModel;
        }
        public static MasterDifficultyViewModel MapToMasterDifficultyViewModel(this MasterDifficulty masterdifficulty)
        {
            var masterdifficultyViewModel = new MasterDifficultyViewModel();

            if (masterdifficulty == null)
            {
                return masterdifficultyViewModel;
            }
            masterdifficultyViewModel = new MasterDifficultyViewModel()
            {
                MasterDifficultyID = masterdifficulty.MasterDifficultyID,
                Wording = masterdifficulty.Wording,
            };
            return masterdifficultyViewModel;
        }
        public static UserViewModel MapToUserViewModel(this User user)
        {
            var userViewModel = new UserViewModel();

            if (user == null)
            {
                return userViewModel;
            }
            userViewModel = new UserViewModel()
            {
                UserID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName, 
                Tel = user.PhoneNumber,
                EmailAddress = user.Email,
                Society = user.Society
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
