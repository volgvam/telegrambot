using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AquarelleBot.API.Telegram
{
    public static class MenuGeneral
    {
        /// <summary>
        /// Главное меню
        /// </summary>
        /// 

    

        public static ReplyKeyboardMarkup GeneralGet(long chatId)
        {

            TelegramBot.Get().SendChatActionAsync(chatId, ChatAction.Typing);


            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
{

                      new[] // second row
                    {
                        new KeyboardButton(MenuGeneralText.ButtomGetPhones),
                        new KeyboardButton(MenuGeneralText.ButtomGetBirthday),

                    }

/*
,

                    new[] // first row
                    {
                        new InlineKeyboardButton("Посмотреть оплату"),
                        new InlineKeyboardButton("Посмотреть анкету"),
                    },
*/  
                });


            string Text = "*Главное меню* \r\n"
                + "Выберите, что Вас интересует";
            TelegramBot.Get().SendTextMessageAsync(chatId, Text, false, true, 0, keyboard, ParseMode.Markdown);

//            TelegramBot.Get().SendTextMessageAsync(chatId, "", replyMarkup: keyboard);



            return keyboard;
        }

    }

    static class MenuGeneralText
    {
        public const string ButtomGetPhones = "Сотрудники";
        public const string ButtomGetBirthday = "Дни рождения";

//        public const string ButtomOldTZ = "ТЗ";
    }
}
