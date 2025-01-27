using Menus;
using Models;
using Server;

class MenuLogin
{
    // Função principal para executar o menu de login
    public void Execute()
    {
        // Instancia o servidor e obtém a lista de usuários
        Server1 server = new();
        List<User> userList = server.ReturnListUser();

        // Loop até o usuário decidir sair
        while (true)
        {
            Console.Clear();  // Limpa a tela do console para uma visualização limpa

            // Exibe o título de boas-vindas usando a classe Menu
            Menu menu = new();
            menu.showTitle("Bem-vindo ao TaskMaster!");

            // Exibe as opções de login
            Console.WriteLine("\nDigite 1 para Login");
            Console.WriteLine("Digite -1 para Sair");

            Console.Write("Digite a sua opção: ");
            string chosenOption = Console.ReadLine()!;  // Obtém a entrada do usuário

            // Verifica se a entrada é um número inteiro válido
            if (int.TryParse(chosenOption, out int chosenOptionNumber))
            {
                // Executa com base na opção escolhida
                switch (chosenOptionNumber)
                {
                    case 1:
                        // Se o usuário escolher logar, executa o menu de login com a lista de usuários
                        MenuLoginIn menuLoginIn = new();
                        menuLoginIn.Execute(userList);
                        return;  // Sai após o login
                    case -1:
                        // Se o usuário escolher sair, exibe uma mensagem e termina a aplicação
                        Console.WriteLine("Até logo!");
                        Environment.Exit(0);
                        return;
                    default:
                        // Lida com uma entrada de opção inválida
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(2000);  // Espera 2 segundos antes de atualizar a tela
                        break;
                }
            }
            else
            {
                // Lida com entradas não numéricas
                Console.WriteLine("Entrada inválida");
                Thread.Sleep(2000);  // Espera 2 segundos antes de atualizar a tela
                Execute();  // Reinicia o menu
            }
        }
    }
}