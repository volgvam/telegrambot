using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using AquarelleBot.API.Personal;
using AquarelleBot.API.Telegram.menu.Phone;
using AquarelleBot.API.Telegram.menu;

namespace AquarelleBot.API.Telegram
{
    //    [DbContext(typeof(DomainModelPostgreSqlContext))]
    public class TelegramPost
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// 

        private AquarelleModelPostgreSqlContext _context;

        public void Message(Message message, AquarelleModelPostgreSqlContext context)
        {

            _context = context;

                long chatId = message.Chat.Id;
                string readChoiseButtomInBd = _context.StateModel.Where(e => e.ChatId == chatId).Select(e => e.TextButon).DefaultIfEmpty("").LastOrDefault();

                if (readChoiseButtomInBd.Count() != 0  )
                {
                }
                else if (message.Text == "IT")
                {
                    _context.StateModel.Add(new StateModel { ChatId = chatId, TextButon = "Регистрация" });
                    _context.SaveChanges();

                    TelegramBot.Get().SendTextMessageAsync(message.Chat.Id, "Доступ открыт!");
                    MenuGeneral.GeneralGet(chatId);

                }
                else
                {
                    TelegramBot.Get().SendTextMessageAsync(message.Chat.Id, "Доступ закрыт! Назовите волшебное слово... )");
                }



                switch (readChoiseButtomInBd)
                {

                    case MenuGeneralText.ButtomGetPhones:


                        TelegramBot.Get().SendChatActionAsync(chatId, ChatAction.Typing);

                        PhoneView phone = new PhoneView();
                        phone.GetPhone(chatId, 33333, message.Text);

                        Task.Delay(100);

                        TelegramBot.Get().SendTextMessageAsync(message.Chat.Id, "Если не нашли, попробуйте еще раз.");

                        break;


                    case MenuPhonesText.ButtomSearchPhones:


                        TelegramBot.Get().SendTextMessageAsync(chatId, "Кого ищем? Введите имя, фамилию или компанию");

                        break;


                    default:



                        break;
                }


        }

        public void MessagePostDirectBot(long chatId, string message)
        {
                TelegramBot.Get().SendTextMessageAsync(chatId, message,false,true,0,null,ParseMode.Html);
        }

        public void MessageEditDirectBot(long chatId, int messgaeId, string message)
        {
            TelegramBot.Get().EditMessageTextAsync(chatId, messgaeId, message, ParseMode.Html, false, null);
        }



        public async void ChosenInlineResult(CallbackQuery update, AquarelleModelPostgreSqlContext context)
        {
            _context = context;

            PhoneView phoneView = new PhoneView();

            long chatId = update.Message.Chat.Id;
            int messageId = update.Message.MessageId;

            var buttomText = update.Data;

            _context.StateModel.Add(new StateModel { ChatId = chatId, TextButon = buttomText });
            _context.SaveChanges();


            switch (buttomText)
            {



                case MenuGeneralText.ButtomGetPhones:


                    await TelegramBot.Get().SendTextMessageAsync(chatId, "Кого ищем? Введите имя, фамилию или компанию");
                    break;


                case MenuPhonesText.ButtomSearchPhones:


                    await TelegramBot.Get().SendTextMessageAsync(chatId, "Кого ищем? Введите имя, фамилию или компанию");

                    break;


                default:


                    char[] forSplit = "/".ToCharArray();
                    string splitText = buttomText.Split(forSplit).Last();

                    await Task.Delay(100); // simulate longer running task

                    break;
            }


        }
    }
}