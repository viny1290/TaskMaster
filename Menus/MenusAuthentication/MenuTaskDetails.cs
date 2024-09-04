using Models;

namespace Menus;
class MenuTaskDetails
{
    public void Execute(List<Notice> ListNotice)
    {
        Console.Write("Digite o nome da tarefa para ver detalhes: ");
        String task = Console.ReadLine()!;
        Notice? notice = ListNotice.FirstOrDefault(u => u.Name == task);

        if (notice != null)
        {
            notice.NoticeUpdates();
        }
        else
        {
            Console.WriteLine("Tarefa não Encontrado.");
        }
        Console.WriteLine($"\nDigite qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }
}