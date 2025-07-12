using Models;

namespace Menus;

class MenuExitTask
{
    // Método para exibir tarefas e permitir que o usuário exclua uma tarefa específica
    public void Execute(User user, List<Notice> noticeList)
    {
        Console.Clear();

        // Exibe as tarefas relacionadas ao grupo do usuário e mostra os dias restantes para o prazo de cada tarefa
        foreach (var notice in noticeList)
        {
            if (notice.Group == user.Type)
            {
                DateTime currentTime = DateTime.Now;
                DateTime deadline = notice.Date.AddDays(notice.Term);
                int daysRemaining = (deadline - currentTime).Days;
                Console.WriteLine($"Tarefa: {notice.Name}, {daysRemaining} dia(s) restante(s) até o prazo final");
            }
        }

        // Solicita ao usuário para inserir o nome da tarefa a ser excluída
        Console.Write("Digite o nome da tarefa: ");
        string taskName = Console.ReadLine()!;

        // Procura a tarefa na lista pelo nome
        Notice? taskToDelete = noticeList.FirstOrDefault(n => n.Name == taskName);

        // Se a tarefa for encontrada, exclui-a da lista; caso contrário, mostra uma mensagem de erro
        if (taskToDelete != null)
        {
            noticeList.Remove(taskToDelete);
            Console.WriteLine($"Tarefa {taskName} excluída com sucesso.");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada.");
        }
    }
}
