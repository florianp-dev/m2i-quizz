using System;
using System.Collections.Generic;
using System.Linq;
using ModelEntities.Entities;
using ModelEntities.ModelViews;


namespace Services
{
    public class QuizzService
    {

        private static DataBaseContext _db = new DataBaseContext();

        /// <summary>
         /// Fournit tous les Quizz
         /// </summary>
         /// <returns>Une liste des quizz présents dans la base</returns>
        public List<QuizzViewModel> GetAllQuizzes()
        {
            var quizzViewModel = new List<QuizzViewModel>();
            using (var dbContext = new DataBaseContext())
            {
                var quizzEntities = dbContext.Quizzes.ToList();
                foreach (var quizzEntity in quizzEntities)
                {
                    quizzViewModel.Add(quizzEntity.MapToQuizzViewModel());
                }
            }
            return quizzViewModel;
           // return _db.Quizzes.ToList().Select(u => u.MapToQuizzViewModel()).ToList();
        }

        /// <summary>
        /// Fournit un Quizz en particulier
        /// </summary>
        /// <param name="id">ID du quizz à récupérer</param>
        /// <returns>Retourn le Quizz spécifié</returns>
        public Quizz GetQuizById(int id)
        {
            Quizz rQuizz = new Quizz();
            using (_db)
            {
                rQuizz = _db.Quizzes.Single(m => m.QuizzID == id);
            }       
            return rQuizz;
        }

        /// <summary>
        /// Créer un quizz de manière aléatoire, selon le niveau spécifié
        /// </summary>
        /// <param name="tech">La technologie liée au quizz</param>
        /// <param name="diff">La difficulté du Quizz</param>
        /// <param name="nbQuestions">Le nombre de questions voulues</param>
        /// <param name="fName">Prénom du candidat</param>
        /// <param name="lName">Nom du candidat</param>
        /// <returns>Un quizz créé aléatoirement avec le nombre de questions selon le niveau</returns>
        public Quizz CreateQuiz(Techno tech, Difficulty diff, int nbQuestions, string fName, string lName)
        {
            Quizz quizz = new Quizz
            {
                CandidateFirstname = fName,
                CandidateLastname = lName,
                LinkedTechno = tech,
                LinkedDifficulty = diff,
                NbQuestions = nbQuestions,
                LinkedQuestions = new List<Question>()
            };

            var begginerQuestions = GetQuestionByDifficulty("Débutant")
                .Where(q => q.LinkedTechno.Wording == tech.Wording)
                .ToList();
            var interQuestions = GetQuestionByDifficulty("Intermédiaire")
                .Where(q => q.LinkedTechno.Wording == tech.Wording)
                .ToList();
            var expertQuestions = GetQuestionByDifficulty("Expert")
                .Where(q => q.LinkedTechno.Wording == tech.Wording)
                .ToList();


            quizz.LinkedQuestions.AddRange(GenerateRandomQuestionsList(begginerQuestions, Math.Ceiling(diff.Percent.Beginner * nbQuestions /100)));
            quizz.LinkedQuestions.AddRange(GenerateRandomQuestionsList(interQuestions, Math.Ceiling(diff.Percent.Intermediate * nbQuestions/100)));
            quizz.LinkedQuestions.AddRange(GenerateRandomQuestionsList(expertQuestions, Math.Ceiling(diff.Percent.Expert * nbQuestions/100)));

            return quizz;
        }

        /// <summary>
        /// Ajoute une réponse à une question
        /// </summary>
        /// <param name="idQuestion">ID de la question à laquelle ajouter une réponse</param>
        /// <param name="answer">La réponse à ajouter</param>
        public void AddQuizAnswer(int idQuestion, Answer answer)
       {
           using (_db)
           {
                _db.Questions.Find(idQuestion).LinkedResponse.Add(answer);
               _db.SaveChanges();
           }

       }

       /// <summary>
       /// Ajoute une liste de réponses
       /// </summary>
       /// <param name="answers">Liste de réponses à ajouter</param>
        public void AddQuizAnswers(List<Answer> answers)
        {
            using (_db)
            {
                foreach (var result in answers)
                {
                    _db.Answers.Add(result);
                    _db.SaveChanges();
                }
               
            }

        }

        /// <summary>
        /// Fournit une liste aléatoire de questions
        /// </summary>
        /// <param name="source">La liste dans laquelle chercher les questions</param>
        /// <param name="rate">Le nombre de questions à chercher</param>
        /// <returns>Une liste de questions piochées aléatoirement</returns>
        private List<Question> GenerateRandomQuestionsList(List<Question> source, decimal rate)
        {
            var quest = new List<Question>();
            var rand = new Random();

            for (var i = 0; i < rate; i++)
            {
                var indice = rand.Next(source.Count);
                quest.Add(source[indice]);
                source.RemoveAt(indice);
            }

            return quest;
        }
        public static List<Question> GetQuestionByDifficulty(string diff)
        {
            return _db.Questions
                .Where(q => q.LinkedDifficulty.Wording == diff)
                .Where(q => q.IsActive)
                .ToList();
        }
    }
}
