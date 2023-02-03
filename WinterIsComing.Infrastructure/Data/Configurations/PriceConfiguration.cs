using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WinterIsComing.Infrastructure.Data.Models;

namespace WinterIsComing.Infrastructure.Data.Configurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            //Bansko

            builder.HasData(new Price
            {
                Id = "d2477f38-8927-4c5e-a875-1e617d167871",
                Value = 90,
                PassType = Enums.PassType.FullDay,
                ResortId = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
            });

            builder.HasData(new Price
            {
                Id = "59f29a21-69eb-47b2-ab5f-760050e3330d",
                Value = 70,
                PassType = Enums.PassType.HalfDay,
                ResortId = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
            });

            builder.HasData(new Price
            {
                Id = "9c587e25-5941-496c-aa6d-c2bc688a8877",
                Value = 1700,
                PassType = Enums.PassType.Seasonal,
                ResortId = "7f412e7c-3999-476e-8f5f-a7a14440ea4b",
            });

            //Borovets

            builder.HasData(new Price
            {
                Id = "09c02bc4-5ba9-43ee-b79f-dc18842c8e0b",
                Value = 85,
                PassType = Enums.PassType.FullDay,
                ResortId = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
            });

            builder.HasData(new Price
            {
                Id = "b8816896-8c30-49b1-9173-a8c0cf70dd39",
                Value = 70,
                PassType = Enums.PassType.HalfDay,
                ResortId = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
            });

            builder.HasData(new Price
            {
                Id = "08050311-981e-4e03-8837-95c550c92a2e",
                Value = 1500,
                PassType = Enums.PassType.Seasonal,
                ResortId = "be4598ef-38d2-4acb-bf23-8b859d4a2b21",
            });

            //Pamporovo

            builder.HasData(new Price
            {
                Id = "5e9370d6-fc61-4c39-b33b-1d83e85e40a1",
                Value = 85,
                PassType = Enums.PassType.FullDay,
                ResortId = "4b604930-85d7-44d5-9d4b-4844d1745742",
            });

            builder.HasData(new Price
            {
                Id = "c799e62e-50f3-441f-8c4a-26fae8db5339",
                Value = 63,
                PassType = Enums.PassType.HalfDay,
                ResortId = "4b604930-85d7-44d5-9d4b-4844d1745742",
            });

            builder.HasData(new Price
            {
                Id = "ebc0e4f5-8eaf-45a1-8797-85220f027593",
                Value = 1530,
                PassType = Enums.PassType.Seasonal,
                ResortId = "4b604930-85d7-44d5-9d4b-4844d1745742",
            });

            //Vitosha

            builder.HasData(new Price
            {
                Id = "374705e6-309f-4ec0-9936-4c1cc15c527a",
                Value = 50,
                PassType = Enums.PassType.FullDay,
                ResortId = "bd83c318-a14f-4113-9408-0d71d19beb98",
            });

            builder.HasData(new Price
            {
                Id = "3d25295a-76b4-4a6e-ac2b-ccc75f50bbfd",
                Value = 40,
                PassType = Enums.PassType.HalfDay,
                ResortId = "bd83c318-a14f-4113-9408-0d71d19beb98",
            });

            builder.HasData(new Price
            {
                Id = "baf8f5d8-583d-4815-af0b-a0027b2e46f5",
                Value = 650,
                PassType = Enums.PassType.Seasonal,
                ResortId = "bd83c318-a14f-4113-9408-0d71d19beb98",
            });

            //Kartala

            builder.HasData(new Price
            {
                Id = "dd8ca596-0912-4a6e-8479-8d966962a23e",
                Value = 60,
                PassType = Enums.PassType.FullDay,
                ResortId = "4b94a373-e809-4f52-90c2-af49ed73cb30",
            });

            builder.HasData(new Price
            {
                Id = "93b23e49-c762-47df-813f-046012736838",
                Value = 45,
                PassType = Enums.PassType.HalfDay,
                ResortId = "4b94a373-e809-4f52-90c2-af49ed73cb30",
            });

            //Bezbog

            builder.HasData(new Price
            {
                Id = "827d687e-6ca8-417a-b16c-42b5a93f25c8",
                Value = 47,
                PassType = Enums.PassType.FullDay,
                ResortId = "79e82d3d-7482-4ffe-8c1c-55a0e47798ec",
            });

            //Malyovitsa

            builder.HasData(new Price
            {
                Id = "626ce16f-e1e6-4e1b-bb43-08253a60717b",
                Value = 25,
                PassType = Enums.PassType.FullDay,
                ResortId = "239fb5bc-f32a-44ff-ad30-992feda18a41",
            });

            builder.HasData(new Price
            {
                Id = "29f08d0a-bf1e-44ca-93af-ce05b2832275",
                Value = 18,
                PassType = Enums.PassType.HalfDay,
                ResortId = "239fb5bc-f32a-44ff-ad30-992feda18a41",
            });

            //Rila Lakes

            builder.HasData(new Price
            {
                Id = "515cd33d-742a-40b3-a664-b5a1136c988a",
                Value = 40,
                PassType = Enums.PassType.FullDay,
                ResortId = "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116",
            });

            builder.HasData(new Price
            {
                Id = "bbda776e-f33a-43a0-9b58-9657785b39f2",
                Value = 30,
                PassType = Enums.PassType.HalfDay,
                ResortId = "2d5a0fa8-fcb9-46d7-8f19-01f5fb543116",
            });
        }
    }
}
