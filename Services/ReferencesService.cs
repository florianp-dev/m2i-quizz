/// <remarks>
/// Florian POUCHELET
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;

namespace Services
{
    public class ReferencesService
    {

        private static DataBaseContext db = new DataBaseContext();

        /// <summary>
        /// Procure la liste des difficultés
        /// </summary>
        /// <returns>Une liste des difficultés disponibles</returns>
        public static List<Difficulty> getSkills()
        {
            return db.Difficulties.ToList();
        }

        /// <summary>
        /// Procure la liste des technolgies
        /// </summary>
        /// <returns>Une liste des technos dispo</returns>
        public static List<Techno> GetTechnos()
        {
            return db.Technos.ToList();
        }

        public static List<Question> GetQuestionByDifficulty(string diff)
        {
            return db.Questions
                .Where(q => q.Wording == diff)
                .ToList();
        }
    }
}
