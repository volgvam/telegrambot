using Telegram.Bot;

namespace AquarelleBot.API.Telegram
{

    public static class TelegramBot
    {

        private static TelegramBotClient _bot;
//        string danceBotTokien = Configuration("TelegramBot:DanceBotTokien");


        public static TelegramBotClient Get()
        {

            if (_bot != null) return _bot;

            _bot = new TelegramBotClient(ConfigTelegram.BotApiKey);

            _bot.SetWebhookAsync(ConfigTelegram.WebHookUrl);


            return _bot;


        }

    }

    public class ConfigTelegram
    {
        /// <summary>
        /// Настройки для бота храним в настройках приложения
        /// </summary>
 //       private static readonly NameValueCollection Appsettings = ConfigurationManager.AppSettings;

        /// <summary>
        /// Полученный токен для бота
        /// </summary>
        public static string BotApiKey
        {
            get { return "11111111:KJhkjhKJhkhkjHKjhk"; }
        }

        /// <summary>
        /// URL, на который должны приходить все обновления от бота
        /// </summary>
        public static string WebHookUrl
        {
            get { return "https://xxxxxxx.ru/api/telegram/aquarelle_bot/"; }
        }

        public static long TestChatId
        {
            get { return 000000; }
        }




    }

        public static class IdTextInlineKeyboardCallbackQuery
        {
            public const string Group = "group/";

        }
}
