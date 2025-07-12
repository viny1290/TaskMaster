using Models;
using Server;

namespace Menus;

class MenuNewMeeting
{
    // Método para criar e agendar uma nova reunião
    public void Execute()
    {
        Server1 server = new();
        List<User> userList = server.ReturnListUser(); // Recupera a lista de usuários do servidor

        Console.Clear(); // Limpa o console
        Console.Write("Digite o nome da reunião: ");
        string meetingName = Console.ReadLine()!;
        Console.Write("Digite em quantos dias a reunião ocorrerá: ");
        string meetingDay = Console.ReadLine()!;

        // Analisa a entrada para determinar o dia da reunião
        if (int.TryParse(meetingDay, out int meetingDayValue))
        {
            DateTime currentTime = DateTime.Now;
            DateTime expectedDate = currentTime.Date.AddDays(meetingDayValue); // Calcula a data da reunião

            // Pede ao usuário para especificar o grupo para a reunião
            Console.WriteLine("Digite 1 para Back-End");
            Console.WriteLine("Digite 2 para Front-End");
            Console.WriteLine("Digite 3 para Todos");
            Console.Write("Digite o grupo que terá a reunião: ");
            string meetingType = Console.ReadLine()!;

            // Define o grupo com base na entrada do usuário
            string group = meetingType switch
            {
                "1" => "Back-End",
                "2" => "Front-End",
                "3" => "Todos",
                _ => ""
            };

            // Valida a entrada do grupo
            if (string.IsNullOrEmpty(group))
            {
                Console.WriteLine("Entrada inválida para o grupo da tarefa.");
            }
            else
            {
                // Cria uma nova reunião
                Meeting newMeeting = new Meeting(meetingName, group, expectedDate);

                // Atribui a reunião aos usuários relevantes com base no grupo
                if (group != "Todos")
                {
                    foreach (User u in userList)
                    {
                        if (u.Type == group)
                        {
                            u.AddMeeting(newMeeting); // Adiciona a reunião ao calendário do usuário
                        }
                    }
                }
                else
                {
                    foreach (User u in userList)
                    {
                        u.AddMeeting(newMeeting); // Adiciona a reunião aos calendários de todos os usuários
                    }
                }
            }

            // Confirma a criação da reunião
            Console.WriteLine($"Reunião {meetingName} criada e enviada a todos.");
            Console.WriteLine($"Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }
        else
        {
            // Lida com entrada inválida
            Console.WriteLine("Entrada inválida.");
            Thread.Sleep(3000); // Pausa por 3 segundos
        }
    }
}