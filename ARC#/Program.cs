using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


// class Lesson
// {
//     public string Subject {get; set;}      
//     public List<string> Notes {get; set;}
// }

class Program
{
    static async Task Main()
    {
        using var cts = new CancellationTokenSource();
        var bot = new TelegramBotClient("BOT_TOKEN", cancellationToken: cts.Token);
        var me = await bot.GetMe();
        bot.OnMessage += OnMessage;

        Console.WriteLine($"@{me.Username} is running... Press Enter to terminate");
        Console.ReadLine();
        cts.Cancel(); // stop the bot

        // method that handle messages received by the bot:
        async Task OnMessage(Message msg, UpdateType type)
        {
            if (msg.Text is null) return;	// we only handle Text messages here
            Console.WriteLine($"Received {type} '{msg.Text}' in {msg.Chat}");
            // let's echo back received text in the chat
            await bot.SendMessage(msg.Chat, $"{msg.From} said: {msg.Text}");
        }

    //     bool isProgram = true;     

    //     string[] tuesdayLessons = File.ReadAllLines("tuesday.txt");
    //     string[] mondayLessons = File.ReadAllLines("monday.txt");

    //     while (isProgram)
    //     {
    //         Console.Write("Какая неделя? (1, 2, ... 5)\n");

    //         int input = Convert.ToInt32(Console.ReadLine());

    //         switch (input)
    //         {
    //             case 1:
    //                 Console.WriteLine("\n1. Посмотреть расписание.\n2. Добавить/удалить заметки к предмету.\n3. Редактировать расписание\n4. Выход.\n");
    //                 int week = Convert.ToInt32(Console.ReadLine());

    //                 switch (week)
    //                 {
    //                     case 1:
    //                         MondayLessons(mondayLessons);
    //                         break;

    //                     case 2:
    //                         Console.WriteLine("Добавить (1), удалить (2)");
    //                         int addOrDelete = Convert.ToInt32(Console.ReadLine());

    //                         switch (addOrDelete)
    //                         {
    //                             case 1:
    //                                 Console.Write("\n: ");

    //                                 break;
    //                         }
    //                         break;
    //                 }
    //                 break;   

    //             case 2:
    //                 Console.WriteLine("\n1. Посмотреть расписание.\n2. Добавить/удалить заметки к предмету.\n3. Редактировать расписание\n4. Выход.\n");
    //                 int week2 = Convert.ToInt32(Console.ReadLine());

    //                 switch (week2)
    //                 {
    //                     case 1:
    //                         TuesdayLessons(tuesdayLessons);
    //                         break;

    //                     case 2:
    //                         Console.WriteLine("Добавить (1), удалить (2)");
    //                         int addOrDelete = Convert.ToInt32(Console.ReadLine());

    //                         switch (addOrDelete)
    //                         {
    //                             case 1:
    //                                 Console.Write("\n: ");

    //                                 break;
    //                         }
    //                         break;
    //                 }
    //                 break;  



    //             case 4:
    //                 isProgram = false;
    //                 break;
    //         }
    //     }
    // }


    // static void MondayLessons(string[] mondayLessons)
    // {
    //     foreach(string number in mondayLessons)
    //     {
    //         Console.Write("\n" + number);
    //     }
    // }
    // static void TuesdayLessons(string[] tuesdayLessons)
    // {
    //     foreach(string number in tuesdayLessons)
    //     {
    //         Console.Write("\n" + number);
    //     }
    }


}