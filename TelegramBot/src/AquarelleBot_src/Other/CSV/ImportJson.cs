using AquarelleBot.API.Telegram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static AquarelleBot.API.Personal.Model.PhoneModel;

namespace AquarelleBot.Other.CSV
{
    public class ImportJson
    {

        private AquarelleModelPostgreSqlContext _context;

        public ImportJson(AquarelleModelPostgreSqlContext context)
        {
            _context = context;
        }

        public async void ImportPhone()
        {


            string addr = @"http://vadim.info/Content/Downloads/jgjhgayqo67yqre.json";
            TelegramPost telegramPost = new TelegramPost();



            var client = new HttpClient();
            


                client.BaseAddress = new Uri(addr);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(addr);
                //                       ToTelegram("Authorization: " + ZadarmaApiConfig.key + ":" + fullQueryStr);

                if (response.IsSuccessStatusCode)
                {

                    List<RootobjectPhoneItems> phones = await response.Content.ReadAsAsync<List<RootobjectPhoneItems>>();

                    RootobjectPhoneItems tempPhoneModel;


                    //                    telegramPost.MessagePostDirectBot(chatId, searhRezult.Count().ToString());
                    try { 
                            foreach (RootobjectPhoneItems phone in phones)
                            {
                                    tempPhoneModel = new RootobjectPhoneItems {
        //                            Id = phone.Id,
                                    FirstName =  phone.FirstName,
                                    LastName= phone.LastName,
                                    Organization= phone.Organization,
                                    PhoneStationary= phone.PhoneStationary,
                                    PhoneHandheld= phone.PhoneHandheld,
                                    PhoneMobile= phone.PhoneMobile,
                                    email= phone.email,
                                    Service= phone.Service,
                                    Birthday= phone.Birthday,
                                    MiddleName = phone.MiddleName
                                };


                        _context.RootobjectPhoneItems.Add(tempPhoneModel);
                        _context.Dispose();

                            
                        //                        context.SaveChanges();
                        telegramPost.MessagePostDirectBot(ConfigTelegram.TestChatId, "Готово");

                    }

                    }
                    catch (Exception ex)
                    {
                        await TelegramBot.Get().SendTextMessageAsync(ConfigTelegram.TestChatId, "Ошибка: " + ex.Message);
                    }


                    //                    telegramPost.MessageEditDirectBot(chatId, messageId, text);

                    //                    telegramPost.MessagePostDirectBot(chatId, text);



                
            }

        }
    }
}
