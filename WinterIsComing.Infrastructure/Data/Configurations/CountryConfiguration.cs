using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Infrastructure.Data.Configurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country
            {
                Id = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
                Name = "Bulgaria",
            });

            builder.HasData(new Country
            {
                Id = "6f511291-50cf-4bb1-bd29-9c1dc627bf76",
                Name = "Austria",
            });

            builder.HasData(new Country
            {
                Id = "2e2bfac9-4671-4b3f-8684-100b21e60b30",
                Name = "Greece",
            });

            builder.HasData(new Country
            {
                Id = "d3312ea7-f12a-4e69-97a4-8a05c951626c",
                Name = "Serbia",
            });

            builder.HasData(new Country
            {
                Id = "7734eba6-bbd6-413b-aa0d-4e990edb57a3",
                Name = "Romania",
            });

            builder.HasData(new Country
            {
                Id = "f332fd70-5e14-4973-b46f-c769912ddc03",
                Name = "Italy",
            });

            builder.HasData(new Country
            {
                Id = "526ac75f-18c7-47c0-bc3c-733074a607e2",
                Name = "France",
            });

            builder.HasData(new Country
            {
                Id = "f666482f-e90f-4e22-9d3d-69c3ee5442c2",
                Name = "Slovenia",
            });

            builder.HasData(new Country
            {
                Id = "37c00aa0-b7de-4df2-9277-da14ab91d122",
                Name = "Andora",
            });
        }
    }
}
