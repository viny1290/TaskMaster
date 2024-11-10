using Models;

namespace Menus;

class MenuLoginIn : Menu
{
    // Function to execute the login process for the user
    public void Execute(List<User> userList)
    {
        Console.Clear();  // Clear the console for a clean login prompt
        MenuLogin menuLogin = new();  // Instantiate MenuLogin for redirection if needed

        // Check if there are any registered users
        if (userList.Count == 0)
        {
            Console.WriteLine("No users registered.");
            Thread.Sleep(3000);  // Pause to allow the user to read the message
            return;  // Exit if no users exist
        }

        // Prompt user to enter their access username
        Console.Write("Enter your Username: ");
        string name = Console.ReadLine()!;
        User? user = userList.FirstOrDefault(u => u.Name == name);  // Find user by name

        // Check if the user exists in the list
        if (user != null)
        {
            // Prompt user to enter their password
            Console.Write("Enter your Password: ");
            string password = Console.ReadLine()!;

            // Verify that the password is numeric and matches the user's stored password
            if (int.TryParse(password, out int passwordNumber))
            {
                if (passwordNumber == user.Password)
                {
                    // If password is correct, navigate to authenticated menu
                    MenuAuthentication menuAuthentication = new();
                    menuAuthentication.Execute(user);  // Execute authenticated menu for the user
                }
                else
                {
                    // If password is incorrect, show error message and return to login
                    Console.WriteLine("Incorrect Password.");
                    Thread.Sleep(3000);  // Pause to allow user to read the message
                    menuLogin.Execute();  // Restart login process
                }
            }
        }
        else
        {
            // If username is not found, show error message and return to login
            Console.WriteLine("User not found.");
            Thread.Sleep(3000);  // Pause to allow user to read the message
            menuLogin.Execute();  // Restart login process
        }
    }
}
