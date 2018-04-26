using System.Collections.Generic;
using System.Linq;
using ModelEntities.Entities;
using ModelEntities.ModelViews;

namespace Services
{
    public class UserService
    {
        public List<UserViewModel> GetAllUsers()
        {
            var userViewModel = new List<UserViewModel>();
            using (var dbContext = new DataBaseContext())
            {
                var userEntities = dbContext.Users.ToList();
                foreach (var userEntity in userEntities)
                {
                    userViewModel.Add(userEntity.MapToUserViewModel());
                }
            }
            return userViewModel;
        }
    }
}
