using Models;
using Server;

namespace Menus;
class MenuAuthentication : Menu
{
    public void Executer(User user)
    {
        bool Senior = user.Position == "Senior" || user.Position == "Pleno" ? true : false;
        bool Pleno = user.Position == "Pleno" ? true : false;
        Server1 server = new();
        List<Notice> ListNotice = server.ReturnListNotice();
        bool isPleno = user.Position == "PLeno";

        Dictionary<int, Action> menuActions = new();
        menuActions.Add(1, () => new MenuDisplayTasks().Execute(user, ListNotice));
        menuActions.Add(2, () => user.MostrarMeetings(DateTime.Now));
        menuActions.Add(3, () => user.ReplacePassword(user));
        menuActions.Add(4, () => server.NewUserList());
        menuActions.Add(5, () => server.NewNoticeList());
        menuActions.Add(6, () => server.NewNoticeList());
        menuActions.Add(7, () => new MenuSubmitReviewTask().Execute(user));
        menuActions.Add(8, () => new MenuNewMeeting().Execute());
        menuActions.Add(9, () => new MenuExitTask().Execute(user, ListNotice));
        menuActions.Add(10, () => new MenuReviewTasks().Execute(user, ListNotice));
        menuActions.Add(-1, () =>
        {
            Console.WriteLine("Tchau tchau!");
            Thread.Sleep(3000);
            new MenuLogin().Execute();
        });

        void ExecuteIfPleno(bool isPleno, Action action)
        {
            if (isPleno)
            {
                action();
            }
            else
            {
                Console.WriteLine("Entrada inválida");
                Thread.Sleep(3000);
            }
        }

        void ExecuteMenu()
        {
            Console.Clear();
            showTitle($"Suas Opções de Tarefas {user.Name}");
            user.YourMeeting();
            Console.WriteLine($"\nDigite 1 para Exibir as tarefas do grupo de {user.Type}");
            Console.WriteLine("Digite 2 para Exibir suas Reuniões");
            Console.WriteLine("Digite 3 para Redefinir senha");

            if (Senior)
            {
                Console.WriteLine("Digite 4 para criar novo usuario");
                Console.WriteLine("Digite 5 para excluir usuario");
                Console.WriteLine("Digite 6 para criar tarefa");
                Console.WriteLine("Digite 7 para enviar tarefa para revisão");
                Console.WriteLine("Digite 8 para marcar uma Reunião");
            }

            if (Pleno)
            {
                Console.WriteLine("Digite 9 para Excluir uma nota");
                Console.WriteLine("Digite 10 para ver tarefas em revição");
            }

            Console.WriteLine("Digite -1 para Sair");
            Console.Write("Digite sua opção: ");

            string chosenOption = Console.ReadLine()!;

            if (int.TryParse(chosenOption, out int chosenOptionNumber))
            {
                if (menuActions.TryGetValue(chosenOptionNumber, out Action action))
                {
                    action();
                    ExecuteMenu();
                }
                else
                {
                    Console.WriteLine("Opção Inválida");
                    Thread.Sleep(3000);
                }
            }
            else
            {
                Console.WriteLine("Opção Inválida");
                Thread.Sleep(3000);
            }
        }

        ExecuteMenu();
    }
}
