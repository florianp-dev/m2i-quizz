using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    class TechnoViewModel
    {
        [Display(Name = "Technologie : ")]
        public int TechnoID { get; set; }

        [Required]
        [Display(Name = "Libellé : ")]
        public string Wording { get; set; }
    }
}
