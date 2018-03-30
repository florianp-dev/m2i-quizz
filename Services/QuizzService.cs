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

        private static DataBaseContext db = new DataBaseContext();
        /* 
         
        
         
         
        
         */
         /* GetAllQuizzes() : retourner la liste de tous les Quizz */
        public static List<Quizz> GetAllQuizzes()
        {
            return db.Quizzes.ToList();
        }

        /* GetQuizById() : retourner un Quiz par id */
        public static Quizz GetQuizById(int Id)
        {
            Quizz rQuizz = new Quizz();
            using (db)
            {
                rQuizz = db.Quizzes.Single(m => m.QuizzID == Id);
            }       
            return rQuizz;
        }

        /* CreateQuiz : Créer le quiz et les questions liées*/
        public void CreateQuiz(Quizz unQuizz)
        {
            using (db)
            {
                db.Quizzes.Add(unQuizz);
                db.SaveChanges();
            }
        }

        /* UpdateQuizAnswer : sauvegarder la(es) réponse(s) pour une question donnée*/
        public void AddQuizAnswer(int idQuestion, Answer unResult)
       {
           using (db)
           {
               db.Answers.Add(unResult);
               db.SaveChanges();
           }

       }

       /* UpdateQuizAnswers : sauvegarder la(es) réponse(s) pour toute les questions du Quiz.*/
        public void AddQuizAnswers(List<Answer> desResult)
        {
            using (db)
            {
                foreach (var result in desResult)
                {
                    db.Answers.Add(result);
                    db.SaveChanges();
                }
               
            }

        }
    }
}
