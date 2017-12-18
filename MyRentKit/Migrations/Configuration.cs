namespace MyRentKit.Migrations
{
    using MyRentKit.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyRentKit.Models.EquipmentDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyRentKit.Models.EquipmentDBContext context)
        {
            context.Equipments.AddOrUpdate(i => i.Title, new Equipment
            {
                Title = "Burt XS",
                Price = 233,
                Category = "Snowboard",
                State = "Perfect"
            },
            new Equipment
            {
                Title = "James X",
                Price = 333,
                Category = "Windsurfing",
                State = "Small scratch"
            }
        );
        

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
