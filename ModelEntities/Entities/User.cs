/// <remarks>
/// Florian POUCHELET
/// </remarks>
/// <summary>
/// Représente les utilisateurs de l'application
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelEntities.Entities
{
    class User
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Society { get; set; }
        public bool IsAdmin { get; set; }
        #endregion

        #region Associations
        public virtual ICollection<Quizz> LinkedQuizz { get; set; }
        #endregion
    }
}
