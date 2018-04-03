using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using ModelEntities.Entities;
using ModelEntities.ModelViews;

namespace Services
{
    public class DifficultiesService
    {
        public List<DifficultyViewModel> GetAllDifficulty()
        {
            var difficultyViewModel = new List<DifficultyViewModel>();
            using (var dbContext = new DataBaseContext())
            {
                var difficultyEntities = dbContext.Difficulties.ToList();
                foreach (var difficultyEntity in difficultyEntities)
                {
                    difficultyViewModel.Add(difficultyEntity.MapToDifficultyViewModel());
                }
            }
            return difficultyViewModel;
        }
    }
}
