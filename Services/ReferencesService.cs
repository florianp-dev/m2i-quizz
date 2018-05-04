/// <remarks>
/// Florian POUCHELET
/// </remarks>

using System.Collections.Generic;
using System.Linq;
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

        
    }
}
