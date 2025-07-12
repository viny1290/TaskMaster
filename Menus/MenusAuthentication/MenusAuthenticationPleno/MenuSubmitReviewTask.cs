using Models;
using Server;

namespace Menus;

class MenuSubmitReviewTask
{
    // Método para enviar uma tarefa para revisão
    public void Execute(User user)
    {
        Server1 server = new();
        List<Notice> listNotice = server.ReturnListNotice(); // Recupera a lista de tarefas do servidor
        if (listNotice.Count != 0)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear(); // Limpa o console
                foreach (var notice in listNotice)
                {
                    if (notice.Group == user.Type) // Verifica se a tarefa pertence ao grupo do usuário
                    {
                        if (notice.Progress == "Development") // Mostra apenas as tarefas em "Desenvolvimento"
                        {
                            DateTime time = DateTime.Now;
                            DateTime expectedDate = notice.Date.AddDays(notice.Term); // Calcula a data esperada da tarefa
                            int daysRemaining = (expectedDate - time).Days; // Calcula os dias restantes
                            Console.WriteLine($"Tarefa: {notice.Name}, faltam {daysRemaining} dia(s) para o prazo final");
                        }
                    }
                }

                // Fornece opções para o usuário
                Console.WriteLine("\nDigite 1 para enviar uma tarefa para revisão");
                Console.WriteLine("Digite -1 para voltar");
                Console.Write("Digite sua opção: ");
                string chosenOption = Console.ReadLine()!;

                // Lida com a escolha do usuário
                if (int.TryParse(chosenOption, out int chosenOptionNumber))
                {
                    switch (chosenOptionNumber)
                    {
                        case 1:
                            // Usuário quer enviar uma tarefa para revisão
                            Console.Write("Digite o nome da tarefa para atualizar: ");
                            string taskName = Console.ReadLine()!;
                            Notice? taskToReview = listNotice.FirstOrDefault(u => u.Name == taskName);

                            if (taskToReview != null)
                            {
                                // Atualiza o progresso da tarefa para "Revisão"
                                taskToReview.NewUpdate(user.Name, "Finalizado", "Revisão");
                                Console.WriteLine("Tarefa enviada para revisão com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Tarefa não encontrada.");
                            }
                            Thread.Sleep(3000); // Espera por 3 segundos antes de continuar
                            break;
                        case -1:
                            // Usuário escolhe sair
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
            // Nenhuma tarefa disponível para o grupo do usuário
            Console.WriteLine("Sua equipe não tem tarefas");
        }

        // Solicita para retornar ao menu
        Console.WriteLine($"Pressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
}
