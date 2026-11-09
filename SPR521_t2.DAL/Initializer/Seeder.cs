namespace SPR521_t2.DAL;

using SPR521_t2.DAL.Entities;

public static class Seeder
{
    public static void Seed(AppDbContext context)
    {

        //Roles

        if (!context.Roles.Any())
        {
            context.Roles.Add(new Role { Name = "Admin" });
            context.Roles.Add(new Role { Name = "User" });
            context.SaveChanges();
        }

        //Users

        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                UserName = "Admin",
                Email = "admin@sushi.com",
                DateOfBirth = DateTime.SpecifyKind(new DateTime(1990, 1, 1), DateTimeKind.Utc),
                PasswordHash = "admin123",
                RoleId = 1
            });
            context.SaveChanges();
        }

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