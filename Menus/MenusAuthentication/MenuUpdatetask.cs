using Models;

namespace Menus;
class MenuUpdatetask
{
    public void Execute(User user, List<Notice> ListNotice)
    {
        Console.Write("Digite o nome da tarefa para Atualizar: ");
        String tarefa = Console.ReadLine()!;
        Notice? notice = ListNotice.FirstOrDefault(u => u.Name == tarefa);

        if (notice != null)
        {
            Console.Write("Digite sua Atualização: ");
            String texto = Console.ReadLine()!;

            notice.NewUpdate(user.Name, texto, "Desenvolvimento");

            Console.WriteLine("Tarefa Atualizada com sucesso");
        }
        else
        {
            Console.WriteLine("Tarefa não Encontrado.");
        }
        Thread.Sleep(3000);
    }
}