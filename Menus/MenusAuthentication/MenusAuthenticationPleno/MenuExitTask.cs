using Models;

namespace Menus;
class MenuExitTask
{
    public void Execute(User user, List<Notice> ListNotice)
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
}