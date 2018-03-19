/// <remarks>
/// David ZIPPARI
/// </remarks>
/// <summary>
/// Regroupe toute les fonctionnalités de l'application
/// </summary>

using ModelEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IService
    {
        #region ReferenceService
        bool CreateQuiz(); // Créer le quiz et les questions liées
        bool UpdateQuizAnswer(Answer answer); //Sauvegarder la(es) IQuizService(s) pour une question donnée
        bool UpdateQuizAnswers(List<Answer> answers); //Sauvegarder la(es) IQuizService(s) pour toute les questions du Quiz.
        Quizz GetQuizById(int id);  //Retourner un Quiz par id
        List<Quizz> GetAllQuizzes(); //Retourner la liste de tous les Quizz
        #endregion

    }
}
