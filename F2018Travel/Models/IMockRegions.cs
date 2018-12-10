using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2018Travel.Models
{
    public interface IMockRegions
    {
        IQueryable<Region> Regions { get; }
        Region Save(Region region);
        void Delete(int id);
    }
}
