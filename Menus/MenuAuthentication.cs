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

        while (true)
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
                switch (chosenOptionNumber)
                {
                    case 1:
                        MenuDisplayTasks menuDisplayTasks = new();
                        menuDisplayTasks.Execute(user, ListNotice);
                        break;
                    case 2:
                        DateTime date = DateTime.Now;
                        user.MostrarMeetings(date);
                        break;
                    case 3:
                        user.ReplacePassword(user);
                        break;
                    case 4:
                        if (Senior)
                        {
                            server.NewUserList();
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida");
                            Thread.Sleep(2000);
                        }
                        break;
                    case 5:
                        if (Senior)
                        {
                            server.ExitUserList();
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida");
                            Thread.Sleep(2000);
                        }
                        break;
                    case 6:
                        if (Pleno)
                        {
                            server.NewNoticeList();
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida");
                            Thread.Sleep(2000);
                        }
                        break;
                    case 7:
                        if (Senior)
                        {
                            MenuSubmitReviewTask menuSubmitReviwTask = new();
                            menuSubmitReviwTask.Execute(user);
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida");
                            Thread.Sleep(3000);
                        }
                        break;
                    case 8:
                        if (Senior)
                        {
                            MenuNewMeeting menuNewMeeting = new();
                            menuNewMeeting.Execute();
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida");
                            Thread.Sleep(2000);
                        }
                        break;
                    case 9:
                        if (Pleno)
                        {
                            Console.Clear();
                            foreach (var notice in ListNotice)
                            {
                                if (notice.Group == user.Type)
                                {
                                    DateTime time = DateTime.Now;
                                    DateTime expectedDate = notice.Date.AddDays(notice.Term);
                                    int daysRemaining = (expectedDate - time).Days;
                                    Console.WriteLine($"Tarefa: {notice.Name}, falta {daysRemaining} dia(s) para o fim do prazo");

                                }
                            }
                            Console.Write("Digite o nome da tarefa: ");
                            string tarefaName = Console.ReadLine()!;

                            Notice? noticeSearch = ListNotice.FirstOrDefault(u => u.Name == tarefaName);

                            if (noticeSearch != null)
                            {
                                ListNotice.Remove(noticeSearch);

                                Console.WriteLine($"Tarefa {tarefaName} excluida com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Tarefa não Encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida");
                        }
                        Thread.Sleep(3000);
                        break;
                    case 10:
                        if (Pleno)
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
                        else
                        {
                            Console.WriteLine("Entrada inválida");
                            Thread.Sleep(2000);
                        }
                        break;
                    case -1:
                        Console.WriteLine("Tchau tchau!");
                        Thread.Sleep(3000);
                        MenuLogin menuLogin = new();
                        menuLogin.Execute();
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(3000);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida");
                Thread.Sleep(2000);
            }
        }
    }
}
