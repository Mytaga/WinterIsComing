using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Core.Models
{
    public class ResortDto
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Elevation { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Likes { get; set; }

        public int NumberOfSlopes { get; set; }

        public double SkiAreaSizes { get; set; }

        public string CountryName { get; set; } = null!;

        public ICollection<ResortPriceDto> LiftPrices { get; set; } = new HashSet<ResortPriceDto>();    
    }
}
