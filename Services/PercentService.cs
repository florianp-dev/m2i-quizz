using System;
using System.Collections.Generic;
using System.Linq;
using ModelEntities.Entities;

namespace Services
{
    public class PercentService
    {
        public List<Percent> GetAllPercents()
        {
            List<Percent> percents = new List<Percent>();
            using (var dbContext = new DataBaseContext())
            {
                percents = dbContext.Percents.ToList();
            }
            return percents;
        }

        public Percent GetPercentById(int id)
        {
            Percent p;
            using (var dbContext = new DataBaseContext())
            {
                p = dbContext.Percents.Find(id);
            }
            return p;
        }
    }
}
