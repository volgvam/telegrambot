using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using AquarelleBot.API.Telegram;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using System.Web.Http;
using AquarelleBot.API.Telegram.menu;
using System.IO;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AquarelleBot.API
{
    [Route("api/telegram/[controller]")]
    public class Aquarelle_botController : ApiController
    {
        //        Configuration tokien = new Configuration["telegramDanceBot:tokien"];
        //        TelegramBotClient Bot = new TelegramBotClient(Config.BotApiKey);


        private AquarelleModelPostgreSqlContext _context;

        public Aquarelle_botController(AquarelleModelPostgreSqlContext context)
        {
            _context = context;
        }





        [HttpPost]
        public async Task<OkResult> Post(Update update)
        {
            var message = update.Message;

//            Console.WriteLine("Received Message from {0}", message.Chat.Id);

            if (message.Type == MessageType.TextMessage)
            {
                // Echo each Message
                await TelegramBot.Get().SendTextMessageAsync(message.Chat.Id, message.Text);

                await Task.Run(() => new TelegramPost().Message(message, _context));


            }
            else if (message.Type == MessageType.PhotoMessage)
            {
                // Download Photo
                var file = await TelegramBot.Get().GetFileAsync(message.Photo.LastOrDefault()?.FileId);

                var filename = file.FileId + "." + file.FilePath.Split('.').Last();

                using (var saveImageStream = System.IO.File.Open(filename, FileMode.Create))
                {
                    await file.FileStream.CopyToAsync(saveImageStream);
                }

                await TelegramBot.Get().SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
            }

            return Ok();
        }












        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }




        // POST api/values
        public async Task<OkResult> Post1([FromBody]Update update)
        {

            //                    _context.StateModel.Add(new StateModel {ChatId= chatId , TextButon= buttomText });
//             _context.StateModel.Add(new StateModel { ChatId = 2333322, TextButon = "ljlkjlkjlkj" });

            //                    var test = _context.Company.ToList();
  //          _context.SaveChanges();


            try
            {

                var message = update.Message;
//                long chatId = update.Message.Chat.Id;

                if (message != null) {

                    if (message.Type == MessageType.TextMessage)
                    {

                        //                        await TelegramBot.Get().SendTextMessageAsync(Config.TestChatId, "Вы написали: " + message.Text);

                        await Task.Run(() => new TelegramPost().Message(message, _context));

                        return Ok();
                    }

                }


                var buttomText = update.CallbackQuery.Data;

                //                await TelegramBot.Get().SendTextMessageAsync(Config.TestChatId, "Вы нажали: " + buttom);



                await Task.Run(() => new TelegramPost().ChosenInlineResult(update.CallbackQuery, _context));
                return Ok();

            }
            catch (Exception ex)
            {
                await TelegramBot.Get().SendTextMessageAsync(ConfigTelegram.TestChatId, "Ошибка: " + ex.Message);
            }


                //            var text = value.CallbackQuery.Data;

                //                        await Task.Run(() => new Vadim_info().MessageAsync(value));
                //            await Task.Run(() => new Vadim_info().Message(value));
                //            await TelegramBot.Get().SendTextMessageAsync(Config.TestChatId, "");
                //            await TelegramBot.Get().SendTextMessageAsync(Config.TestChatId, value.CallbackQuery.Data.ToString());


                //            var me = Bot.GetMeAsync().Result;
                return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
