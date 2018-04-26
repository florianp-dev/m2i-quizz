using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
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
        public List<SelectListItem> SetPercentDropDownList()
        {
            //Ne pas utiliser le DbContext depuis un controller.
            var percentListItems = new List<SelectListItem>();
            using (var dbContext = new DataBaseContext())
            {
                var percents = dbContext.Percents;
                foreach (var percent in percents)
                {
                    percentListItems.Add(new SelectListItem()
                    {
                        Value = percent.PercentID.ToString(),
                        Text = "Débutant " + percent.Beginner +  " Intermédiaire " + percent.Intermediate + " Expert " + percent.Expert,

                    });
                }

                return percentListItems;
            }
        }
    }
}
