using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquarelleBot.API.Telegram;
using AquarelleBot.API.Telegram.Model;
using AquarelleBot.Other.CSV;
using AquarelleBot.API.Personal;
using AquarelleBot.API.Telegram.menu;
using AquarelleBot.API.Telegram.menu.Phone;

namespace AquarelleBot.Controllers
{
    public class HomeController : Controller
    {

        private AquarelleModelPostgreSqlContext _context;

        public HomeController(AquarelleModelPostgreSqlContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            //            PersonData personData = new PersonData();

            return View();
        }

        public IActionResult About()
        {

            MenuPhones.MenuGeneralGetMarkup(ConfigTelegram.TestChatId);


            ViewData["Message"] = "";//importCSV.Get();

            return View();
        }

        public IActionResult Contact()
        {

            ImportJson importJson = new ImportJson(_context);
            importJson.ImportPhone();

            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
