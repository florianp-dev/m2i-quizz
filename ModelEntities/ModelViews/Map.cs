using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;

namespace ModelEntities.ModelViews
{
     public static class Map
    {
        public static DifficultyViewModel MapToDifficultyViewModel(this Difficulty difficulty)
        {
            var difficultyViewModel = new DifficultyViewModel();

            if (difficulty == null)
            {
                return difficultyViewModel;
            }
            difficultyViewModel = new DifficultyViewModel()
            {
                DifficultyID = difficulty.DifficultyID,
                Wording = difficulty.Wording,
            };
            return difficultyViewModel;
        }
        public static MasterDifficultyViewModel MapToMasterDifficultyViewModel(this MasterDifficulty masterdifficulty)
        {
            var masterdifficultyViewModel = new MasterDifficultyViewModel();

            if (masterdifficulty == null)
            {
                return masterdifficultyViewModel;
            }
            masterdifficultyViewModel = new MasterDifficultyViewModel()
            {
                MasterDifficultyID = masterdifficulty.MasterDifficultyID,
                Wording = masterdifficulty.Wording,
            };
            return masterdifficultyViewModel;
        }

    }
}
