using LifeBot.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace LifeBot
{
    class Program
    {
        private static TelegramBotClient bot;

        static void Main(string[] args)
        {           

            LifeBotContext db = new LifeBotContext();
            string TGToken = db.Config.Where(c => c.ConfId == 1L).Single().ConfValue;

            bot = new TelegramBotClient(TGToken);
            bot.OnMessage += readMessage;
            bot.StartReceiving();
            Console.ReadLine();
            bot.StopReceiving();

            /*
            Users test = db.Users.Where(u=>u.UserId == 1l).Single();
            Console.WriteLine("User: " + test.UserId + " - " + test.UserFamily + ", " + test.UserGiven);
            db.TxtAccounts.Where(t=>t.UserId == test.UserId).ToList().ForEach(t => Console.WriteLine(t.TxtAcctName));

            db.SaveChanges();
            */
        }

        private static void readMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                Console.WriteLine("Sender: " + e.Message.Chat.Id + " Message: " + e.Message.Text);
                bot.SendTextMessageAsync(e.Message.Chat.Id, " I hear you man");
            }
                
        }
    }
}
