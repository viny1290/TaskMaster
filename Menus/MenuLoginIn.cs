using Models;

namespace Menus;
class MenuLoginIn : Menu
{
    public void Execute(List<User> ListUser)
    {
        Console.Clear();
        MenuLogin menuLogin = new();

        if (ListUser.Count == 0)
        {
            Console.WriteLine("Nenhum usuário registrado.");
            Thread.Sleep(3000);
            return;
        }

        Console.Write("Digite o Usuario de Acesso: ");
        string name = Console.ReadLine()!;
        User? user = ListUser.FirstOrDefault(u => u.Name == name);

        if (user != null)
        {
            Console.Write("Digite a Senha de Usuario: ");
            string password = Console.ReadLine()!;

            if (int.TryParse(password, out int passwordNumber))
            {
                if (passwordNumber == user.Password)
                {
                    MenuAuthentication menuAuthentication = new();
                    menuAuthentication.Executer(user);
                }
                else
                {
                    Console.WriteLine("Senha Incorreta.");
                    Thread.Sleep(3000);
                    menuLogin.Execute();
                }
            }
        }
        else
        {
            Console.WriteLine("Usuario não Encontrado.");
            Thread.Sleep(3000);
            menuLogin.Execute();
        }
    }
}