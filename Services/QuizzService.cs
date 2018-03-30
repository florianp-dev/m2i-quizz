using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /* CreateQuiz : Créer le quiz et les questions liées*/
        public void CreateQuiz(Quizz unQuizz)
        {
            // TODO Générer le quizz aléatoirement selon difficulté
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
    }
}
