using Models;

namespace Menus;

class MenuLoginIn : Menu
{
    // Função para executar o processo de login do usuário
    public void Execute(List<User> userList)
    {
        Console.Clear();  // Limpa o console para exibir uma tela de login limpa
        MenuLogin menuLogin = new();  // Instancia o MenuLogin para redirecionar caso necessário

        // Verifica se há usuários cadastrados
        if (userList.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            Thread.Sleep(3000);  // Pausa por 3 segundos para o usuário ler a mensagem
            return;  // Sai da função se não houver usuários cadastrados
        }

        // Solicita que o usuário digite seu nome de usuário
        Console.Write("Digite seu Nome de Usuário: ");
        string name = Console.ReadLine()!;  // Lê o nome do usuário digitado
        User? user = userList.FirstOrDefault(u => u.Name == name);  // Busca o usuário pelo nome

        // Verifica se o usuário foi encontrado na lista
        if (user != null)
        {
            // Solicita que o usuário digite a senha
            Console.Write("Digite sua Senha: ");
            string password = Console.ReadLine()!;  // Lê a senha digitada

            // Verifica se a senha digitada é numérica e se corresponde à senha armazenada
            if (int.TryParse(password, out int passwordNumber))
            {
                if (passwordNumber == user.Password)
                {
                    // Se a senha estiver correta, redireciona para o menu autenticado
                    MenuAuthentication menuAuthentication = new();
                    menuAuthentication.Execute(user);  // Executa o menu autenticado para o usuário
                }
                else
                {
                    // Se a senha estiver incorreta, exibe a mensagem de erro e reinicia o processo de login
                    Console.WriteLine("Senha Incorreta.");
                    Thread.Sleep(3000);  // Pausa por 3 segundos para o usuário ler a mensagem
                    menuLogin.Execute();  // Reinicia o processo de login
                }
            }
        }
        else
        {
            // Se o nome de usuário não for encontrado, exibe a mensagem de erro e reinicia o processo de login
            Console.WriteLine("Usuário não encontrado.");
            Thread.Sleep(3000);  // Pausa por 3 segundos para o usuário ler a mensagem
            menuLogin.Execute();  // Reinicia o processo de login
        }
    }
}