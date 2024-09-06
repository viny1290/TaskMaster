using Models;

namespace Server;
class Server1
{
    static List<User> ListUser = new();
    static List<Notice> ListNotice = new();
    public List<User> ReturnListUser()
    {
        if (ListUser.Count == 0)
        {
            ListUser.Add(new User("Vinicius", 1234, "Senior", "Back-End"));
        }
        return ListUser;
    }
    public List<Notice> ReturnListNotice()
    {
        if (ListNotice.Count == 0)
        {
            ListNotice.Add(new Notice("Atualizar metodos do Notice", "Criado", "Back-End", new DateTime(2024, 9, 1), 10));
        }
        return ListNotice;
    }

    public void NewUserList()
    {
        Console.Clear();
        Console.Write("Digite nome do novo usuario: ");
        string newUserName = Console.ReadLine()!;

        User? userSearch = ListUser.FirstOrDefault(u => u.Name == newUserName);

        if (userSearch == null)
        {
            Console.WriteLine("Digite 1 para Back-End");
            Console.WriteLine("Digite 2 para Front-End");
            Console.Write("Digite o time do novo usuario: ");
            string newUserType = Console.ReadLine()!;

            string group = newUserType switch
            {
                "1" => "Back-End",
                "2" => "Front-End",
                _ => ""
            };
            User newUser = new User(newUserName, 1234, "Junior", group);
            ListUser.Add(newUser);

            Console.WriteLine($"Usuario(a) criado com sucesso, bem vindo(a) {newUser.Name} ao nosso time");
            Console.WriteLine("A senha padrao de um novo usuario e 1234");
        }
        else
        {
            Console.WriteLine($"Usuario(a) {userSearch.Name} já cadastrado");
        }
        Console.WriteLine($"Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    public void ExitUserList()
    {
        Console.Clear();
        Console.Write("Digite o nome do usuario: ");
        string userName = Console.ReadLine()!;

        User? userSearch = ListUser.FirstOrDefault(u => u.Name == userName);

        if (userSearch != null)
        {
            ListUser.Remove(userSearch);

            Console.WriteLine($"Usuario {userName} excluido com sucesso do nosso time");
        }
        else
        {
            Console.WriteLine("Usuario não Encontrado.");
        }
        Console.WriteLine($"Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    public void NewNoticeList()
    {
        Console.Clear();
        Console.Write("Digite o nome da tarefa: ");
        string newNoticeName = Console.ReadLine()!;

        Notice? noticeSearch = ListNotice.FirstOrDefault(u => u.Name == newNoticeName);

        if (noticeSearch == null)
        {
            Console.WriteLine("Digite 1 para Back-End");
            Console.WriteLine("Digite 2 para Front-End");
            Console.Write("\nDigite o time da tarefa: ");
            string noticeGroup = Console.ReadLine()!;

            string group = noticeGroup switch
            {
                "1" => "Back-End",
                "2" => "Front-End",
                _ => ""
            };

            if (string.IsNullOrEmpty(group))
            {
                Console.WriteLine("Entrada inválida para o time da tarefa.");
            }
            else
            {
                Console.Write("Digite o tempo da tarefa em dias: ");
                string term = Console.ReadLine()!;
                DateTime dateCurrentTime = DateTime.Now;

                if (int.TryParse(term, out int termDay))
                {
                    Notice newNotice = new Notice(newNoticeName, "Criado", group, dateCurrentTime, termDay);
                    ListNotice.Add(newNotice);
                }
                else
                {
                    Console.WriteLine("Entrada inválida para o tempo da tarefa.");
                }
            }
        }
        else
        {
            Console.WriteLine($"Tarefa {newNoticeName} já cadastrada");
        }
        Console.WriteLine($"Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }
}