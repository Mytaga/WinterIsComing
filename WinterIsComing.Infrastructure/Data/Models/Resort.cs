﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static WinterIsComing.Common.Constants.ModelValidationConstants;

namespace WinterIsComing.Infrastructure.Data.Models
{
    public class Resort
    {
        public Resort()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Users = new HashSet<AppUser>();
            this.LiftPassPrices = new HashSet<Price>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(ResortValidation.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ResortValidation.ElevationMaxLength)]
        public string Elevation { get; set; } = null!;

        [Required]
        [StringLength(ResortValidation.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ResortValidation.ImageUrlMaxLength)]
        public string ImageUrl { get; set;} = null!;

        public int Likes { get; set; }

        [Required]
        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;

        public virtual ICollection<AppUser> Users { get; set; }

        public virtual ICollection<Price> LiftPassPrices { get; set; }
    }
}
