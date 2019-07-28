using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquarelleBot.API.Telegram.Model
{
    public class PersonData
    {
        private readonly AquarelleModelPostgreSqlContext _context;

        public PersonData(AquarelleModelPostgreSqlContext context)
        {

            _context = context;

            TypeCompany typeCompany = new TypeCompany();
            typeCompany = new TypeCompany{ Name = "Администрация" };


//            typeCompany.Name =  "Администрация";
 //           {
//               new TypeCompany { Name = "Администрация"}
//                new TypeCompany { Name = "Арендатор"},
//                new TypeCompany { Name = "Подрядчик"}

//            };

            _context.TypeCompany.Add(typeCompany);
            _context.SaveChanges();

        }

    }
}
