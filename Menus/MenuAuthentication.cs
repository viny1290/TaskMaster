using Models;
using Server;

namespace Menus;

class MenuAuthentication : Menu
{
    // Método para executar as ações do menu de autenticação com base no cargo do usuário
    public void Execute(User user)
    {
        Server1 server = new();
        List<Notice> noticeList = server.ReturnListNotice();

        // Define os cargos do usuário para controle de acesso
        bool isSenior = user.Position == "Senior" || user.Position == "Pleno";
        bool isPleno = user.Position == "Pleno";

        // Dicionário para mapear as opções do menu para as ações
        Dictionary<int, Action> menuActions = new();
        menuActions.Add(1, () => new MenuDisplayTasks().Execute(user, noticeList));  // Exibir tarefas do grupo
        menuActions.Add(2, () => user.ShowMeetings(DateTime.Now));                    // Exibir reuniões
        menuActions.Add(3, () => user.ReplacePassword(user));                         // Alterar senha
        menuActions.Add(4, () => ExecuteIfSeniorOrPleno(isPleno, () => server.NewUserList()));  // Criar novo usuário
        menuActions.Add(5, () => ExecuteIfSeniorOrPleno(isPleno, () => server.NewNoticeList())); // Excluir usuário
        menuActions.Add(6, () => ExecuteIfSeniorOrPleno(isPleno, () => server.NewNoticeList())); // Criar tarefa
        menuActions.Add(7, () => ExecuteIfSeniorOrPleno(isPleno, () => new MenuSubmitReviewTask().Execute(user))); // Enviar tarefa para revisão
        menuActions.Add(8, () => ExecuteIfSeniorOrPleno(isPleno, () => new MenuNewMeeting().Execute()));  // Agendar reunião
        menuActions.Add(9, () => ExecuteIfSeniorOrPleno(isSenior, () => new MenuExitTask().Execute(user, noticeList))); // Excluir nota
        menuActions.Add(10, () => ExecuteIfSeniorOrPleno(isSenior, () => new MenuReviewTasks().Execute(user, noticeList))); // Ver tarefas em revisão
        menuActions.Add(-1, () =>  // Opção de saída
        {
            Console.WriteLine("Até logo!");
            Thread.Sleep(3000);
            new MenuLogin().Execute();  // Retornar ao menu de login
        });

        // Método para executar uma ação apenas se o usuário for Sênior ou Pleno
        void ExecuteIfSeniorOrPleno(bool isSeniorOrPleno, Action action)
        {
            if (isSeniorOrPleno)
            {
                action();  // Executar ação se autorizado
            }
            else
            {
                Console.WriteLine("Entrada inválida");
                Thread.Sleep(3000);  // Pausa antes de atualizar
            }
        }

        // Método para exibir o menu e processar a entrada do usuário
        void ExecuteMenu()
        {
            Console.Clear();
            showTitle($"Suas Opções de Tarefas {user.Name}");  // Exibe o título com o nome do usuário
            user.YourMeeting();  // Exibe as reuniões do usuário

            // Exibe as opções básicas para todos os usuários
            Console.WriteLine($"\nDigite 1 para exibir tarefas do grupo {user.Type}");
            Console.WriteLine("Digite 2 para exibir suas reuniões");
            Console.WriteLine("Digite 3 para alterar sua senha");

            // Exibe opções adicionais para usuários 'Pleno'
            if (isPleno)
            {
                Console.WriteLine("Digite 4 para criar um novo usuário");
                Console.WriteLine("Digite 5 para excluir um usuário");
                Console.WriteLine("Digite 6 para criar uma tarefa");
                Console.WriteLine("Digite 7 para enviar uma tarefa para revisão");
                Console.WriteLine("Digite 8 para agendar uma reunião");
            }

            // Exibe opções adicionais para usuários 'Sênior'
            if (isSenior)
            {
                Console.WriteLine("Digite 9 para excluir uma nota");
                Console.WriteLine("Digite 10 para ver tarefas em revisão");
            }

            Console.WriteLine("Digite -1 para Sair");  // Opção para sair
            Console.Write("Digite sua opção: ");

            // Processa a entrada do usuário
            string chosenOption = Console.ReadLine()!;
            if (int.TryParse(chosenOption, out int chosenOptionNumber))
            {
                // Executa a ação selecionada, se ela existir
                if (menuActions.TryGetValue(chosenOptionNumber, out Action? action) && action != null)
                {
                    action();
                    ExecuteMenu();  // Redesenha o menu após a ação
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(3000);
                }
            }
            else
            {
                Console.WriteLine("Opção inválida");
                Thread.Sleep(3000);
            }
        }

        ExecuteMenu();  // Inicia o loop do menu
    }
}