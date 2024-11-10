namespace Models;
class User
{
    // List to store the meetings of the user
    List<Meeting> ListMeeting = new();

    // Constructor to initialize the user with name, password, position, and type
    public User(string name, int password, string position, string type)
    {
        Name = name;
        Password = password;
        Position = position;
        Type = type;
    }

    // Properties for the user's information
    public string Name { get; }
    public int Password { get; private set; }
    public string Position { get; private set; }
    public string Type { get; private set; }

    // Method to display the user's meetings
    public void YourMeeting()
    {
        DateTime date = DateTime.Now;

        // Remove meetings that have already passed
        foreach (Meeting meeting in ListMeeting)
        {
            if (meeting.Date < date)
            {
                ListMeeting.Remove(meeting);
            }
        }

        // Print a message depending on the number of meetings
        Console.WriteLine($"You {(ListMeeting.Count == 0 ? "don't have" : $"have {ListMeeting.Count}")} scheduled meeting(s).");
    }

    // Method to show the user's meetings on a given date
    public void ShowMeetings(DateTime date)
    {
        Console.Clear();
        foreach (Meeting meeting in ListMeeting)
        {
            string formattedDate = meeting.Date.ToString("dd/MM/yyyy");
            Console.WriteLine($"Meeting {meeting.Name} on {formattedDate}");
        }
        Console.WriteLine($"Press any key to return to the menu");
        Console.ReadKey();
    }

    // Method to add a meeting to the user's list of meetings
    public void AddMeeting(Meeting meeting)
    {
        ListMeeting.Add(meeting);
    }

    // Method to replace the user's password
    public void ReplacePassword(User user)
    {
        // Ask the user to input their current password
        Console.Write("Enter your current password: ");
        string password = Console.ReadLine()!;

        if (int.TryParse(password, out int passwordNumber))
        {
            // Check if the entered password matches the current password
            if (passwordNumber == user.Password)
            {
                while (true)
                {
                    // Ask for a new password
                    Console.Write("Enter your new 4-digit password: ");
                    string NewPassword = Console.ReadLine()!;

                    if (int.TryParse(NewPassword, out int NewPasswordNumber))
                    {
                        // Ensure the new password is exactly 4 digits
                        if (NewPassword.Length == 4)
                        {
                            Password = NewPasswordNumber;
                            Console.WriteLine("Your password has been successfully changed!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. The password must be exactly 4 numeric digits.");
                        }
                    }
                }

            }
            else
            {
                // If the entered password is incorrect, inform the user
                Console.WriteLine("Incorrect password");
                Console.WriteLine("Please ask a superior to reset your password");
            }
        }
        Thread.Sleep(2000); // Pause for 2 seconds before returning to the menu
    }
}