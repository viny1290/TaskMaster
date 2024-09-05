using Menus;
using Models;
using Server;

class MenuLogin
{
    public void Execute()
    {
        Server1 server = new();
        List<User> ListUser = server.ReturnListUser();
        while (true)
        {
            Console.Clear();
            Menu menu = new();
            menu.showTitle("Bem Vindo ao TaskMaster!");
            Console.WriteLine("\nDigite 1 para Logar");
            Console.WriteLine("Digite -1 para Sair");

            Console.Write("Digite sua Opção: ");
            string chosenOption = Console.ReadLine()!;

            if (int.TryParse(chosenOption, out int chosenOptionNumber))
            {
                switch (chosenOptionNumber)
                {
                    case 1:
                        MenuLoginIn menuLoginIn = new();
                        menuLoginIn.Execute(ListUser);
                        return;
                    case -1:
                        Console.WriteLine("Tchau tchau!");
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Opção inválida");
                        Thread.Sleep(2000);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida");
                Thread.Sleep(2000);
                Execute();
            }
        }
    }
}
