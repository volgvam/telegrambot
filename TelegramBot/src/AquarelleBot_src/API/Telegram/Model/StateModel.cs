using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AquarelleBot.API.Telegram.menu
{
    public class StateModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StateModelId { get; set; }
        public long ChatId { get; set; }
        public string TextButon { get; set; }
    }
}
