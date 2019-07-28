using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace AquarelleBot.API.Telegram.menu.Phone
{
    public static class MenuPhones
    {
        /// <summary>
        /// Поиск телефонов
        /// </summary>
        /// 


        public static ReplyKeyboardMarkup MenuGeneralGetMarkup(long chatId)
        {

            ReplyKeyboardMarkup keyboardMarkup = new ReplyKeyboardMarkup(new[] {

                new[] {
                    new KeyboardButton("Сотрудники"),
                    new KeyboardButton("Арендаторы")
                }
                ,
                new[] {
                    new KeyboardButton("Дни рождения"),
                    new KeyboardButton("ТЗ")
                }

            });

                

            

            TelegramBot.Get().SendChatActionAsync(chatId, ChatAction.Typing);
 
            string Text = "Проверка";

            TelegramBot.Get().SendTextMessageAsync(chatId, Text, replyMarkup: keyboardMarkup);


            return keyboardMarkup;

        }

        public static InlineKeyboardMarkup MenuGeneralGet(long chatId)
            {

                TelegramBot.Get().SendChatActionAsync(chatId, ChatAction.Typing);


        InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(new[]
        {

                      new[] // second row
                    {
                        new InlineKeyboardButton(MenuPhonesText.ButtomSearchPhones),
//                        new InlineKeyboardButton(MenuPhonesText.ButtomGetPhones),
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


                string Text = "";

                TelegramBot.Get().SendTextMessageAsync(chatId, Text, false, true, 0, keyboard, ParseMode.Markdown);

                //            TelegramBot.Get().SendTextMessageAsync(chatId, "", replyMarkup: keyboard);



                return keyboard;
            }

        }


        static class MenuPhonesText
        {
            public const string ButtomSearchPhones = "Найти сотрудника";
            public const string ButtomOldTZ = "ТЗ";

        }


    }

