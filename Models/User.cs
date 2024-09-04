namespace Models;
class User
{
    List<Meeting> ListMeeting = new();
    public User(string name, int password, string position, string type)
    {
        Name = name;
        Password = password;
        Position = position;
        Type = type;
    }

    public string Name { get; }
    public int Password { get; private set; }
    public string Position { get; private set; }
    public string Type { get; private set; }

    public void YourMeeting()
    {
        DateTime date = DateTime.Now;

        foreach (Meeting meeting in ListMeeting)
        {
            if (meeting.Date < date)
            {
                ListMeeting.Remove(meeting);
            }
        }

        Console.WriteLine($"Você {(ListMeeting.Count == 0 ? "não tem" : $"tem {ListMeeting.Count}")} reunião(ões) marcada(s).");
    }

    public void MostrarMeetings(DateTime date)
    {
        Console.Clear();
        foreach (Meeting meeting in ListMeeting)
        {
            string formattedDate = meeting.Date.ToString("dd/MM/yyyy");
            Console.WriteLine($"Reunião de {meeting.Name} em {formattedDate}");
        }
        Console.WriteLine($"Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    public void AddMeeting(Meeting meeting)
    {
        ListMeeting.Add(meeting);
    }

    public void ReplacePassword(User user)
    {
        Console.Write("Digite sua senha Atual: ");
        string password = Console.ReadLine()!;

        if (int.TryParse(password, out int passwordNumber))
        {
            if (passwordNumber == user.Password)
            {
                while (true)
                {
                    Console.Write("Digite sua Nova Senha de 4 digitos: ");
                    string NewPassword = Console.ReadLine()!;

                    if (int.TryParse(NewPassword, out int NewPasswordNumber))
                    {
                        if (NewPassword.Length == 4)
                        {
                            Password = NewPasswordNumber;
                            Console.WriteLine("Sua senha foi trocada com sucesso!");
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
                Console.WriteLine("Senha incorreta");
                Console.WriteLine("Peça para um superior resetar sua senha");
            }
        }
        Thread.Sleep(2000);
    }
}