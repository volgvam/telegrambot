using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AquarelleBot.API.Personal.Model
{
    public class PhoneModel
    {


        public class RootobjectPhone
        {

            public List<RootobjectPhoneItems> RootobjectPhoneItems { get; set; }
        }

        public class RootobjectPhoneItems
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public long RootobjectPhoneItemsId { get; set; }
            public string PhoneStationary { get; set; }
            public int? PhoneHandheld { get; set; }
            public string PhoneMobile { get; set; }
            public string Service { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Organization { get; set; }
            public string email { get; set; }
            public string Birthday { get; set; }


        }


    }
}
