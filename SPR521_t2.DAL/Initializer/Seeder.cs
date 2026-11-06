namespace SPR521_t2.DAL;

using SPR521_t2.DAL.Entities;

public static class Seeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.SushiTypes.Any())
        {
            context.SushiTypes.Add(new SushiType { Name = "Роли" });
            context.SushiTypes.Add(new SushiType { Name = "Нігірі" });
            context.SaveChanges();
        }

        if (!context.SushiSets.Any())
        {
            var roll = context.SushiTypes.First(t => t.Name == "Роли");
            var nigiri = context.SushiTypes.First(t => t.Name == "Нігірі");

            context.SushiSets.Add(new SushiSet
            {
                Name = "Філадельфія сет",
                Price = 450,
                Description = "Роли з лососем та вершковим сиром",
                Weight = 600,
                Order = 1,
                SushiTypeId = roll.Id
            });

            context.SushiSets.Add(new SushiSet
            {
                Name = "Каліфорнія сет",
                Price = 380,
                Description = "Роли з крабом та авокадо",
                Weight = 550,
                Order = 2,
                SushiTypeId = roll.Id
            });

            context.SushiSets.Add(new SushiSet
            {
                Name = "Нігірі мікс",
                Price = 320,
                Description = "Нігірі з лососем та тунцем",
                Weight = 400,
                Order = 3,
                SushiTypeId = nigiri.Id
            });

            context.SaveChanges();
        }
    }
}