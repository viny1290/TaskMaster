using Models;

namespace Menus;
class MenuReviewTasks
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
                        if (notice.Progress == "Revisão")
                        {
                            DateTime time = DateTime.Now;
                            DateTime expectedDate = notice.Date.AddDays(notice.Term);
                            int daysRemaining = (expectedDate - time).Days;
                            Console.WriteLine($"Tarefa: {notice.Name}, falta {daysRemaining} dia(s) para o fim do prazo");

                        }
                    }
                }
                Console.WriteLine("\nDigite 1 para finalizar uma Tarefa");
                Console.WriteLine("Digite 2 para retornar uma Tarefa");
                Console.WriteLine("Digite -1 para Voltar");
                Console.Write("Digite sua opção: ");
                String chosenOption1 = Console.ReadLine()!;

                if (int.TryParse(chosenOption1, out int chosenOptionNumber1))
                {
                    switch (chosenOptionNumber1)
                    {
                        case 1:
                            Console.Write("Digite o nome da tarefa para Atualizar: ");
                            String tarefa = Console.ReadLine()!;
                            Notice? notice = ListNotice.FirstOrDefault(u => u.Name == tarefa);
                            if (notice != null)
                            {
                                ListNotice.Remove(notice);
                                Console.WriteLine($"Tarefa {tarefa} finalizada");
                            }
                            else
                            {
                                Console.WriteLine("Tarefa não Encontrado.");
                            }
                            Thread.Sleep(3000);
                            break;
                        case 2:
                            Console.Write("Digite o nome da tarefa para Atualizar: ");
                            String tarefa1 = Console.ReadLine()!;
                            Notice? notice1 = ListNotice.FirstOrDefault(u => u.Name == tarefa1);

                            if (notice1 != null)
                            {
                                Console.Write("Digite sua Atualização: ");
                                String texto = Console.ReadLine()!;

                                notice1.NewUpdate(user.Name, texto, "Desenvolvimento");

                                Console.WriteLine("Tarefa Atualizada com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Tarefa não Encontrado.");
                            }
                            Thread.Sleep(3000);
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