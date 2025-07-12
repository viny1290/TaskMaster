using Models;

namespace Menus;

class MenuTaskDetails
{
    // Método para exibir os detalhes de uma tarefa específica
    public void Execute(List<Notice> noticeList)
    {
        // Solicita ao usuário para inserir o nome da tarefa para visualizar os detalhes
        Console.Write("Digite o nome da tarefa para ver os detalhes: ");
        string taskName = Console.ReadLine()!;

        // Procura a tarefa na lista pelo nome
        Notice? notice = noticeList.FirstOrDefault(n => n.Name == taskName);

        // Se a tarefa for encontrada, exibe seus detalhes; caso contrário, mostra uma mensagem de erro
        if (notice != null)
        {
            notice.NoticeUpdates(); // Exibe as atualizações para a tarefa selecionada
        }
        else
        {
            Console.WriteLine("Tarefa não encontrada."); // Mensagem de erro se a tarefa não for encontrada
        }

        // Solicita para retornar ao menu anterior
        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
}