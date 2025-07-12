using Models;

namespace Menus;

class MenuDisplayTasks
{
    // Método para exibir as tarefas associadas ao grupo do usuário e fornecer opções de ações
    public void Execute(User user, List<Notice> noticeList)
    {
        // Verifica se há alguma tarefa para o grupo do usuário
        if (noticeList.Count != 0)
        {
            bool exit = false;

            // Loop para exibir as tarefas até que o usuário escolha sair
            while (!exit)
            {
                Console.Clear();

                // Exibe as tarefas que pertencem ao grupo do usuário e não estão em revisão
                foreach (var notice in noticeList)
                {
                    if (notice.Group == user.Type) // Verifica se a tarefa pertence ao grupo do usuário
                    {
                        if (notice.Progress != "Revisão") // Exclui tarefas em revisão
                        {
                            DateTime currentTime = DateTime.Now;
                            DateTime expectedEndDate = notice.Date.AddDays(notice.Term);
                            int daysRemaining = (expectedEndDate - currentTime).Days;

                            // Exibe o nome da tarefa e os dias restantes
                            Console.WriteLine($"Tarefa: {notice.Name}, {daysRemaining} dia(s) restante(s) até o prazo");
                        }
                    }
                }

                // Exibe as opções para as ações da tarefa
                Console.WriteLine("\nDigite 1 para Atualizar uma Tarefa");
                Console.WriteLine("Digite 2 para Ver Detalhes da Tarefa");
                Console.WriteLine("Digite -1 para Voltar");
                Console.Write("Digite sua opção: ");

                // Lê e processa a entrada do usuário para as ações do menu
                string chosenOption = Console.ReadLine()!;

                if (int.TryParse(chosenOption, out int chosenOptionNumber))
                {
                    switch (chosenOptionNumber)
                    {
                        case 1:
                            // Inicializa o menu para atualizar uma tarefa
                            MenuUpdatetask menuUpdatetask = new();
                            menuUpdatetask.Execute(user, noticeList);
                            break;
                        case 2:
                            // Inicializa o menu para visualizar os detalhes da tarefa
                            MenuTaskDetails menuTaskDetails = new();
                            menuTaskDetails.Execute(noticeList);
                            break;
                        case -1:
                            exit = true; // Sai do loop e retorna ao menu anterior
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            Thread.Sleep(2000); // Pausa brevemente para permitir que o usuário leia a mensagem
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida"); // Exibe erro para entrada não numérica
                    Thread.Sleep(2000);
                }
            }
        }
        else
        {
            // Mensagem exibida se não houver tarefas para o grupo do usuário
            Console.WriteLine("Sua equipe não tem tarefas");
        }

        Console.WriteLine("Pressione qualquer tecla para retornar ao menu"); // Solicita para retornar ao menu principal
        Console.ReadKey();
    }
}