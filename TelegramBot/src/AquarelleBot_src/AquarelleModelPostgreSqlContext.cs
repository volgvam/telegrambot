using AquarelleBot.API.Telegram.menu;
using AquarelleBot.API.Telegram.Model;
using Microsoft.EntityFrameworkCore;
using static AquarelleBot.API.Personal.Model.PhoneModel;

namespace AquarelleBot
{

    public class AquarelleModelPostgreSqlContext : DbContext
    {

        public AquarelleModelPostgreSqlContext(DbContextOptions<AquarelleModelPostgreSqlContext> options)
        : base(options)
    { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<TypeCompany> TypeCompany { get; set; }
        public DbSet<StateModel> StateModel { get; set; }
        public DbSet<RootobjectPhoneItems> RootobjectPhoneItems { get; set; }


    }
}








