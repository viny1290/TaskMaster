using Models;

namespace Menus;

class MenuReviewTasks
{
    // Método para permitir ao usuário revisar tarefas e finalizá-las ou retorná-las
    public void Execute(User user, List<Notice> noticeList)
    {
        if (noticeList.Count != 0) // Verifica se há tarefas para revisar
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                // Exibe as tarefas que estão em revisão para o grupo do usuário
                foreach (var notice in noticeList)
                {
                    if (notice.Group == user.Type)
                    {
                        if (notice.Progress == "Revisão") // Mostra apenas as tarefas com status "Revisão"
                        {
                            DateTime currentTime = DateTime.Now;
                            DateTime deadline = notice.Date.AddDays(notice.Term);
                            int daysRemaining = (deadline - currentTime).Days;
                            Console.WriteLine($"Tarefa: {notice.Name}, {daysRemaining} dia(s) restante(s) até o prazo final");
                        }
                    }
                }

                // Exibe as opções de menu para revisar tarefas
                Console.WriteLine("\nDigite 1 para finalizar uma tarefa");
                Console.WriteLine("Digite 2 para retornar uma tarefa para mais trabalho");
                Console.WriteLine("Digite -1 para voltar");
                Console.Write("Digite sua opção: ");

                string chosenOption1 = Console.ReadLine()!;

                // Lida com a entrada do usuário e executa as ações correspondentes
                if (int.TryParse(chosenOption1, out int chosenOptionNumber1))
                {
                    switch (chosenOptionNumber1)
                    {
                        case 1: // Finalizar uma tarefa
                            Console.Write("Digite o nome da tarefa para finalizar: ");
                            string taskName = Console.ReadLine()!;
                            Notice? taskToFinalize = noticeList.FirstOrDefault(u => u.Name == taskName);

                            if (taskToFinalize != null)
                            {
                                noticeList.Remove(taskToFinalize); // Remove a tarefa da lista
                                Console.WriteLine($"Tarefa {taskName} finalizada.");
                            }
                            else
                            {
                                Console.WriteLine("Tarefa não encontrada.");
                            }
                            Thread.Sleep(3000); // Pausa por 3 segundos
                            break;

                        case 2: // Retornar uma tarefa para mais atualizações
                            Console.Write("Digite o nome da tarefa para atualizar: ");
                            string taskToUpdateName = Console.ReadLine()!;
                            Notice? taskToUpdate = noticeList.FirstOrDefault(u => u.Name == taskToUpdateName);

                            if (taskToUpdate != null)
                            {
                                Console.Write("Digite sua atualização: ");
                                string updateText = Console.ReadLine()!;

                                taskToUpdate.NewUpdate(user.Name, updateText, "Desenvolvimento"); // Adiciona uma nova atualização à tarefa
                                Console.WriteLine("Tarefa atualizada com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Tarefa não encontrada.");
                            }
                            Thread.Sleep(3000); // Pausa por 3 segundos
                            break;

                        case -1: // Sai do loop e retorna ao menu principal
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Opção inválida."); // Adicionado para lidar com opções inválidas
                            Thread.Sleep(2000);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                    Thread.Sleep(2000);
                }
            }
        }
        else
        {
            Console.WriteLine("Sua equipe não tem tarefas.");
        }

        // Solicita ao usuário para pressionar qualquer tecla para voltar ao menu
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }
}
