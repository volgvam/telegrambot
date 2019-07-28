using AquarelleBot.API.Personal.Model;
using AquarelleBot.API.Telegram;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static AquarelleBot.API.Personal.Model.PhoneModel;

namespace AquarelleBot.API.Personal
{
    public class PhoneView
    {

        public async Task GetPhone(long chatId, int messageId, string search)
        {

            string searchString = search.ToLower();

            string addr = @"http://vadim.info/Content/Downloads/jgjhgayqo67yqre.json";
            TelegramPost telegramPost = new TelegramPost();



            using (var client = new HttpClient())
            {

                CultureInfo cultureInfo = new CultureInfo("ru-RU");


                //                CultureInfo culture = new CultureInfo("ru-RU");

                client.BaseAddress = new Uri(addr);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("month=8"));
                //                telegramPost.MessageDirectBot("Authorization: ");

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync(addr);
                //                       ToTelegram("Authorization: " + ZadarmaApiConfig.key + ":" + fullQueryStr);

                if (response.IsSuccessStatusCode)
                {

                    try { 
                    List<RootobjectPhoneItems> phones = await response.Content.ReadAsAsync<List<RootobjectPhoneItems>>();

                    string text = "";

                    IEnumerable<RootobjectPhoneItems> searhRezult = phones
                        .Where(e =>
                        e.LastName.ToLower().Contains(searchString)
                        || e.FirstName.ToLower().Contains(searchString)
                        || e.MiddleName.ToLower().Contains(searchString)
                        || e.Service.ToLower().Contains(searchString)
                        || e.Organization.ToLower().Contains(searchString)

                        ).OrderBy(e=>e.LastName);

                    telegramPost.MessagePostDirectBot(chatId, "Найдено: " + searhRezult.Count().ToString());

                    Thread.Sleep(50);

                        foreach (RootobjectPhoneItems phone in searhRezult)
                    {

                        text = string.Format(
                             "<b>{0} {1}</b> \r\n"
                            + "{7}\r\n"

                            + "\r\n"
                            + "{2}"
 //                           + "\r\n"
                            +  "{3}"

                            + "{4}"
                            + "{5}"
                            + "{6}"
                            + "\r\n"
                            + "{8} \r\n"
  //                          + "---------------------------------------- \r\n"
//  + phone.email 
                            + "\r\n"

                            , phone.FirstName,
                             phone.LastName,
                             !(string.IsNullOrEmpty(phone.Organization))? "Компания: " + phone.Organization +  "\r\n" : phone.Organization,
                             !(string.IsNullOrEmpty(phone.PhoneStationary)) ? "\U0000260E Стационарный телефон: " + phone.PhoneStationary + " \r\n" : phone.PhoneStationary,
                             phone.PhoneHandheld != null  ? "\U0001F4DE Переносная трубка: " + phone.PhoneHandheld + " \r\n" : null,
                             !(string.IsNullOrEmpty(phone.PhoneMobile)) ? "\U0001F4F1 +7" + phone.PhoneMobile + " \r\n" : phone.PhoneMobile,
                             !(string.IsNullOrEmpty(phone.email))? "\U00002709 "+  phone.email : phone.email,
                             phone.Service,
                             !(string.IsNullOrEmpty(phone.Birthday)) ? "День рождения: " + (DateTime.Parse(phone.Birthday, cultureInfo)).ToString("d MMMM", cultureInfo) : phone.Birthday

                        );

                            Thread.Sleep(50);
                            telegramPost.MessagePostDirectBot(chatId, text);
                    }

                        //                    telegramPost.MessageEditDirectBot(chatId, messageId, text);

                        //                    telegramPost.MessagePostDirectBot(chatId, text);


                    }
                    catch (Exception ex)
                    {
                        await TelegramBot.Get().SendTextMessageAsync(ConfigTelegram.TestChatId, "Ошибка: " + ex.Message);
                    }
                }
            }

        }
    }
}




