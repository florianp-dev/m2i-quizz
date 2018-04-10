/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les utilisateurs de l'application
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ModelEntities.Entities
{
    public class User : IdentityUser
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Society { get; set; }
        #endregion

        #region Associations
        public virtual List<Quizz> LinkedQuizz { get; set; }
        #endregion
    }
}
