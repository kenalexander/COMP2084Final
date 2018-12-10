using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F2018Travel.Models
{
    public class EFRegions : IMockRegions
    {
        private ExamModel db;

        public EFRegions()
        {
            this.db = new ExamModel();
        }

        public IQueryable<Region> Regions { get { return db.Regions; } }

        public void Delete(int id)
        {
            Region region = db.Regions.SingleOrDefault(r => r.RegionId == id);

            db.Regions.Remove(region);
            db.SaveChanges();
        }

        public Region Save(Region region)
        {
            if (region.RegionId == 0)
            {
                db.Regions.Add(region);
            }
            else
            {
                db.Entry(region).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return region;
        }
    }
}