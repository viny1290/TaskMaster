using Models;
using Server;

namespace Menus;
class MenuNewMeeting
{
    public void Execute()
    {
        Server1 server = new();
        List<User> ListUser = server.ReturnListUser();

        Console.Clear();
        Console.Write("Digite nome da Reunião: ");
        string nameMeeting = Console.ReadLine()!;
        Console.Write("Digite em quantos dias vai ser a reunião: ");
        string dayMeeting = Console.ReadLine()!;

        if (int.TryParse(dayMeeting, out int dayMeetingName))
        {
            DateTime time = DateTime.Now;
            DateTime expectedDate = time.Date.AddDays(dayMeetingName);

            Console.WriteLine("Digite 1 para Back-End");
            Console.WriteLine("Digite 2 para Front-End");
            Console.WriteLine("Digite 3 para Todos");
            Console.Write("Digite o time que vai ter Reunião: ");
            string typeMeeting = Console.ReadLine()!;

            string group = typeMeeting switch
            {
                "1" => "Back-End",
                "2" => "Front-End",
                "3" => "Todos",
                _ => ""
            };

            if (string.IsNullOrEmpty(group))
            {
                Console.WriteLine("Entrada inválida para o time da tarefa.");
            }
            else
            {
                Meeting newMeeting = new Meeting(nameMeeting, group, expectedDate);

                if (group != "Todos")
                {
                    foreach (User u in ListUser)
                    {
                        if (u.Type == group)
                        {
                            u.AddMeeting(newMeeting);
                        }
                    }
                }
                else
                {
                    foreach (User u in ListUser)
                    {
                        u.AddMeeting(newMeeting);
                    }
                }
            }

            Console.WriteLine($"reunião {nameMeeting} criada e enviada para todos");
            Console.WriteLine($"Digite qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Entrada inválida");
            Thread.Sleep(3000);
        }
    }
}