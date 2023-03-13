using System.ComponentModel.DataAnnotations;
using WinterIsComing.Infrastructure.Data.Enums;

namespace WinterIsComing.Core.Models.Price
{
    public class AddPriceDto
    {
        [Required]
        public decimal Value { get; set; }

        [Required]
        public PassType PassType { get; set; }

        [Required]
        public string ResortId { get; set; } = null!;
    }
}
