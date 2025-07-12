using Models;

namespace Menus;

class MenuUpdatetask
{
    // Método para atualizar uma tarefa específica com uma nova atualização do usuário
    public void Execute(User user, List<Notice> noticeList)
    {
        // Solicita ao usuário para inserir o nome da tarefa a ser atualizada
        Console.Write("Digite o nome da tarefa para atualizar: ");
        string taskName = Console.ReadLine()!;

        // Procura a tarefa na lista pelo nome
        Notice? notice = noticeList.FirstOrDefault(n => n.Name == taskName);

        // Se a tarefa for encontrada, solicita uma mensagem de atualização; caso contrário, exibe um erro
        if (notice != null)
        {
            Console.Write("Digite sua atualização: ");
            string updateText = Console.ReadLine()!;

            // Registra a nova atualização com o nome do usuário, texto da atualização e status como "Desenvolvimento"
            notice.NewUpdate(user.Name, updateText, "Desenvolvimento");

            Console.WriteLine("Tarefa atualizada com sucesso.");
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada."); // Mensagem de erro se a tarefa não for encontrada
        }

        // Pausa brevemente para permitir que o usuário leia a mensagem
        Thread.Sleep(3000);
    }
}
