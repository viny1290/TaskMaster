namespace Models;

class User
{
    // Lista para armazenar as reuniões do usuário
    List<Meeting> ListMeeting = new();

    // Construtor para inicializar o usuário com nome, senha, cargo e tipo
    public User(string name, int password, string position, string type)
    {
        Name = name;
        Password = password;
        Position = position;
        Type = type;
    }

    // Propriedades para as informações do usuário
    public string Name { get; }
    public int Password { get; private set; }
    public string Position { get; private set; }
    public string Type { get; private set; }

    // Método para exibir as reuniões do usuário
    public void YourMeeting()
    {
        DateTime date = DateTime.Now;

        // Remove reuniões que já passaram
        foreach (Meeting meeting in ListMeeting)
        {
            if (meeting.Date < date)
            {
                ListMeeting.Remove(meeting);
            }
        }

        // Imprime uma mensagem dependendo do número de reuniões
        Console.WriteLine($"Você {(ListMeeting.Count == 0 ? "não tem" : $"tem {ListMeeting.Count}")} reunião(ões) agendada(s).");
    }

    // Método para mostrar as reuniões do usuário em uma determinada data
    public void ShowMeetings(DateTime date)
    {
        Console.Clear();
        foreach (Meeting meeting in ListMeeting)
        {
            string formattedDate = meeting.Date.ToString("dd/MM/yyyy");
            Console.WriteLine($"Reunião {meeting.Name} em {formattedDate}");
        }
        Console.WriteLine($"Pressione qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }

    // Método para adicionar uma reunião à lista de reuniões do usuário
    public void AddMeeting(Meeting meeting)
    {
        ListMeeting.Add(meeting);
    }

    // Método para substituir a senha do usuário
    public void ReplacePassword(User user)
    {
        // Pede ao usuário para inserir a senha atual
        Console.Write("Digite sua senha atual: ");
        string password = Console.ReadLine()!;

        if (int.TryParse(password, out int passwordNumber))
        {
            // Verifica se a senha digitada corresponde à senha atual
            if (passwordNumber == user.Password)
            {
                while (true)
                {
                    // Pede uma nova senha
                    Console.Write("Digite sua nova senha de 4 dígitos: ");
                    string NewPassword = Console.ReadLine()!;

                    if (int.TryParse(NewPassword, out int NewPasswordNumber))
                    {
                        // Garante que a nova senha tenha exatamente 4 dígitos
                        if (NewPassword.Length == 4)
                        {
                            Password = NewPasswordNumber;
                            Console.WriteLine("Sua senha foi alterada com sucesso!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. A senha deve ter exatamente 4 dígitos numéricos.");
                        }
                    }
                }
            }
            else
            {
                // Se a senha digitada estiver incorreta, informa o usuário
                Console.WriteLine("Senha incorreta");
                Console.WriteLine("Por favor, peça a um superior para redefinir sua senha");
            }
        }
        Thread.Sleep(2000); // Pausa por 2 segundos antes de retornar ao menu
    }
}