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
