using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    public class UserViewModel
    {
        public string UserID { get; set; }

        [Required]
        [Display(Name = "Prénom : ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nom : ")]
        public string LastName { get; set; }

        [Display(Name = "Téléphone : ")]
        public string Tel { get; set; }

        [Required]
        [Display(Name = "Adresse Mail : ")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Mot de Passe : ")]
        public string Password { get; set; }

        [Display(Name = "Société : ")]
        public string Society { get; set; }

        [Required]
        [Display(Name = "Administrateur : ")]
        public bool IsAdmin { get; set; }
    }
}