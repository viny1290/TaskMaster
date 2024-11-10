using Menus;
using Models;
using Server;

class MenuLogin
{
    // Main function to execute the login menu
    public void Execute()
    {
        // Instantiate the server and get the list of users
        Server1 server = new();
        List<User> userList = server.ReturnListUser();

        // Loop until the user decides to exit
        while (true)
        {
            Console.Clear();  // Clear the console screen for a fresh view

            // Show the welcome title using the Menu class
            Menu menu = new();
            menu.showTitle("Welcome to TaskMaster!");

            // Display login options
            Console.WriteLine("\nEnter 1 to Login");
            Console.WriteLine("Enter -1 to Exit");

            Console.Write("Enter your option: ");
            string chosenOption = Console.ReadLine()!;  // Get user input

            // Check if input is a valid integer
            if (int.TryParse(chosenOption, out int chosenOptionNumber))
            {
                // Execute based on the chosen option
                switch (chosenOptionNumber)
                {
                    case 1:
                        // If user chooses to log in, execute the login menu with the user list
                        MenuLoginIn menuLoginIn = new();
                        menuLoginIn.Execute(userList);
                        return;  // Exit after login
                    case -1:
                        // If user chooses to exit, show a message and terminate the application
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        return;
                    default:
                        // Handle invalid option input
                        Console.WriteLine("Invalid option");
                        Thread.Sleep(2000);  // Wait before refreshing
                        break;
                }
            }
            else
            {
                // Handle non-integer inputs
                Console.WriteLine("Invalid input");
                Thread.Sleep(2000);  // Wait before refreshing
                Execute();  // Restart the menu
            }
        }
    }
}
