using Models;

namespace Menus;
class MenuDisplayTasks
{
    public void Execute(User user, List<Notice> ListNotice)
    {
        if (ListNotice.Count != 0)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                foreach (var notice in ListNotice)
                {
                    if (notice.Group == user.Type)
                    {
                        if (notice.Progress != "Revisão")
                        {
                            DateTime time = DateTime.Now;
                            DateTime expectedDate = notice.Date.AddDays(notice.Term);
                            int daysRemaining = (expectedDate - time).Days;
                            Console.WriteLine($"Tarefa: {notice.Name}, falta {daysRemaining} dia(s) para o fim do prazo");
                        }
                    }
                }
                Console.WriteLine("\nDigite 1 para Atualizar uma Tarefa");
                Console.WriteLine("Digite 2 para ver detalhes de uma Tarefa");
                Console.WriteLine("Digite -1 para Voltar");
                Console.Write("Digite sua opção: ");

                String chosenOption1 = Console.ReadLine()!;

                if (int.TryParse(chosenOption1, out int chosenOptionNumber1))
                {
                    switch (chosenOptionNumber1)
                    {
                        case 1:
                            MenuUpdatetask menuUpdatetask = new();
                            menuUpdatetask.Execute(user, ListNotice);
                            break;
                        case 2:
                            MenuTaskDetails menuTaskDetails = new();
                            menuTaskDetails.Execute(ListNotice);
                            break;
                        case -1:
                            exit = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida");
                }
            }
        }
        else
        {
            Console.WriteLine("Seu time não tem tarefas");
        }
        Console.WriteLine($"Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }
}