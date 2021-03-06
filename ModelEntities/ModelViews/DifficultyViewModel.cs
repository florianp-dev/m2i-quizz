﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntities.ModelViews
{
    public class DifficultyViewModel
    {
        [Display(Name = "ID Difficulté : ")]
        public int DifficultyID { get; set; }

        [Required]
        [Display(Name = "Libellé : ")]
        public string Wording { get; set; }
    }
}
