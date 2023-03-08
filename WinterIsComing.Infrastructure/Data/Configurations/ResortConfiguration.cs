using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinterIsComing.Infrastructure.Data.Models;
using static System.Net.WebRequestMethods;

namespace WinterIsComing.Infrastructure.Data.Configurations
{
    internal class ResortConfiguration : IEntityTypeConfiguration<Resort>
    {
        public void Configure(EntityTypeBuilder<Resort> builder)
        {
            //Bulgaria

            builder.HasData(new Resort
            {
                Id = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
                Name = "Bansko",
                Elevation = "2600",
                Description = "Bansko is the biggest ski resort in Bulgaria located in the Pirin mountain. It hosts FIS World Cup alpine ski races.",
                ImageUrl = "https://www.skibansko.bg/wp-content/uploads/2016/06/bansko-ski-runs.jpg",
                NumberOfSlopes = 20,
                SkiAreaSize = 75,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });

            builder.HasData(new Resort
            {
                Id = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
                Name = "Borovets",
                Elevation = "2500",
                Description = "Borovets is the second biggest ski resort in Bulgaria located in the Rila mountain.It offers night skiing.",
                ImageUrl = "https://www.skiborovets.bg/wp-content/uploads/2016/08/borovets-night-skiing.jpg",
                NumberOfSlopes = 27,
                SkiAreaSize = 58,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });

            builder.HasData(new Resort
            {
                Id = "4b604930-85d7-44d5-9d4b-4844d1745742",
                Name = "Pamporovo",
                Elevation = "1920",
                Description = "Pamporovo is located in the Rhodope mountain. It offers warm hospitality and is very suitable for beginners.",
                ImageUrl = "https://www.igluski.com/images/_i60381238.jpg",
                NumberOfSlopes = 20,
                SkiAreaSize = 36.8,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });

            builder.HasData(new Resort
            {
                Id = "bd83c318-a14f-4113-9408-0d71d19beb98",
                Name = "Vitosha",
                Elevation = "2200",
                Description = "Vitosha is located just 20km away from Sofia city center.Unfortunately most of the lifts are abandoned and few are working.",
                ImageUrl = "https://www.skiresort.info/fileadmin/_processed_/29/94/4a/a0/ba07658242.jpg",
                NumberOfSlopes = 12,
                SkiAreaSize = 36.8,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });

            builder.HasData(new Resort
            {
                Id = "4b94a373-e809-4f52-90c2-af49ed73cb30",
                Name = "Kartala",
                Elevation = "2350",
                Description = "Kartala is located close to Blagoevgrad in the Rila mountain. Not a lot of slopes but good for freeride.",
                ImageUrl = "https://bg.nexustrace.com/wp-content/uploads/2020/11/kartala-2.jpg",
                NumberOfSlopes = 2,
                SkiAreaSize = 5,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });

            builder.HasData(new Resort
            {
                Id = "79e82d3d-7482-4ffe-8c1c-55a0e47798ec",
                Name = "Bezbog",
                Elevation = "2240",
                Description = "Bezbog is located in the Pirin mountain next to Bansko. There is only one slope but is a favourite site for freeride and backcountry.",
                ImageUrl = "https://bulgariaview.com/view/albums/17/46.jpg",
                NumberOfSlopes = 1,
                SkiAreaSize = 5,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });

            builder.HasData(new Resort
            {
                Id = "239fb5bc-f32a-44ff-ad30-992feda18a41",
                Name = "Malyovitsa",
                Elevation = "2000",
                Description = "Malyovitsa is located in the Rila mountain. There are no lifts just rope tows. It's good for freeride.",
                ImageUrl = "https://4vlast-bg.com/wp-content/uploads/2021/01/89911107_166885198185957_7272630966554722304_o.jpg",
                NumberOfSlopes = 2,
                SkiAreaSize = 4,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });

            builder.HasData(new Resort
            {
                Id = "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116",
                Name = "Rila Lakes",
                Elevation = "2300",
                Description = "Rila Lakes is located in the Rila mountain. There is one slow lift and one rope tows. It's good for freeride and backcountry.",
                ImageUrl = "https://www.360mag.bg/wp-content/uploads/2016/12/bg-kurorti-rilski-ezera.jpg",
                NumberOfSlopes = 2,
                SkiAreaSize = 3,
                CountryId = "3e6773cb-dd81-4f92-91a6-05816ba80c07",
            });
        }
    }
}
