using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEntities.Entities;
using ModelEntities.ModelViews;

namespace Services
{
    public class MasterDifficultiesService
    {
        public List<MasterDifficultyViewModel> GetAllMasterDifficulty()
        {
            var masterdifficultyViewModel = new List<MasterDifficultyViewModel>();
            using (var dbContext = new DataBaseContext())
            {
                var masterdifficultyEntities = dbContext.MasterDifficulties.ToList();
                foreach (var masterdifficultyEntity in masterdifficultyEntities)
                {
                    masterdifficultyViewModel.Add(masterdifficultyEntity.MapToMasterDifficultyViewModel());
                }
            }
            return masterdifficultyViewModel;
        }
    }
}
