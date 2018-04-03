using System;
using System.Collections.Generic;
using System.Linq;
using ModelEntities.Entities;


namespace Services
{
    public class QuizzService
    {

        private static DataBaseContext _db = new DataBaseContext();

        /// <summary>
         /// Fournit tous les Quizz
         /// </summary>
         /// <returns>Une liste des quizz présents dans la base</returns>
        public static List<Quizz> GetAllQuizzes()
        {
            return _db.Quizzes.ToList();
        }

        /// <summary>
        /// Fournit un Quizz en particulier
        /// </summary>
        /// <param name="id">ID du quizz à récupérer</param>
        /// <returns>Retourn le Quizz spécifié</returns>
        public static Quizz GetQuizById(int id)
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
        public Quizz CreateQuiz(Techno tech, MasterDifficulty diff, int nbQuestions, string fName, string lName)
        {
            Quizz quizz = new Quizz
            {
                CandidateFirstname = fName,
                CandidateLastname = lName,
                LinkedTechno = tech,
                LinkedMasterDifficulty = diff,
                NbQuestions = nbQuestions
            };

            var begginerQuestions = ReferencesService.GetQuestionByDifficulty("Débutant");
            var interQuestions = ReferencesService.GetQuestionByDifficulty("Intermédiaire");
            var expertQuestions = ReferencesService.GetQuestionByDifficulty("Expert");

            quizz.LinkedQuestions.AddRange(GenerateRandomQuestionsList(begginerQuestions, (int)diff.LinkedPercent.Beginner * 10));
            quizz.LinkedQuestions.AddRange(GenerateRandomQuestionsList(interQuestions, (int)diff.LinkedPercent.Intermediate * 10));
            quizz.LinkedQuestions.AddRange(GenerateRandomQuestionsList(expertQuestions, (int)diff.LinkedPercent.Expert * 10));

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
        private List<Question> GenerateRandomQuestionsList(List<Question> source, int rate)
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
    }
}
