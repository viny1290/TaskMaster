using Models;
using Server;

namespace Menus;
class MenuAuthentication : Menu
{
    public void Executer(User user)
    {
        Server1 server = new();
        List<Notice> ListNotice = server.ReturnListNotice();
        bool isSenior = user.Position == "Senior" || user.Position == "Pleno";
        bool isPleno = user.Position == "Pleno";

        Dictionary<int, Action> menuActions = new();
        menuActions.Add(1, () => new MenuDisplayTasks().Execute(user, ListNotice));
        menuActions.Add(2, () => user.MostrarMeetings(DateTime.Now));
        menuActions.Add(3, () => user.ReplacePassword(user));
        menuActions.Add(4, () => ExecuteIfSeniorOrPleno(isSenior, () => server.NewUserList()));
        menuActions.Add(5, () => ExecuteIfSeniorOrPleno(isSenior, () => server.NewNoticeList()));
        menuActions.Add(6, () => ExecuteIfSeniorOrPleno(isSenior, () => server.NewNoticeList()));
        menuActions.Add(7, () => ExecuteIfSeniorOrPleno(isSenior, () => new MenuSubmitReviewTask().Execute(user)));
        menuActions.Add(8, () => ExecuteIfSeniorOrPleno(isSenior, () => new MenuNewMeeting().Execute()));
        menuActions.Add(9, () => ExecuteIfSeniorOrPleno(isPleno, () => new MenuExitTask().Execute(user, ListNotice)));
        menuActions.Add(10, () => ExecuteIfSeniorOrPleno(isPleno, () => new MenuReviewTasks().Execute(user, ListNotice)));
        menuActions.Add(-1, () =>
        {
            Console.WriteLine("Tchau tchau!");
            Thread.Sleep(3000);
            new MenuLogin().Execute();
        });

        void ExecuteIfSeniorOrPleno(bool isSeniorOrPleno, Action action)
        {
            if (isSeniorOrPleno)
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

            if (isSenior)
            {
                Console.WriteLine("Digite 4 para criar novo usuario");
                Console.WriteLine("Digite 5 para excluir usuario");
                Console.WriteLine("Digite 6 para criar tarefa");
                Console.WriteLine("Digite 7 para enviar tarefa para revisão");
                Console.WriteLine("Digite 8 para marcar uma Reunião");
            }

            if (isPleno)
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
