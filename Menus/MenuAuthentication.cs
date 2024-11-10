using Models;
using Server;

namespace Menus;

class MenuAuthentication : Menu
{
    // Method to execute authentication menu actions based on user role
    public void Execute(User user)
    {
        Server1 server = new();
        List<Notice> noticeList = server.ReturnListNotice();

        // Define user roles for access control
        bool isSenior = user.Position == "Senior" || user.Position == "Pleno";
        bool isPleno = user.Position == "Pleno";

        // Dictionary to map menu options to actions
        Dictionary<int, Action> menuActions = new();
        menuActions.Add(1, () => new MenuDisplayTasks().Execute(user, noticeList));  // Display group tasks
        menuActions.Add(2, () => user.ShowMeetings(DateTime.Now));                    // Display meetings
        menuActions.Add(3, () => user.ReplacePassword(user));                         // Change password
        menuActions.Add(4, () => ExecuteIfSeniorOrPleno(isPleno, () => server.NewUserList()));  // Create new user
        menuActions.Add(5, () => ExecuteIfSeniorOrPleno(isPleno, () => server.NewNoticeList())); // Delete user
        menuActions.Add(6, () => ExecuteIfSeniorOrPleno(isPleno, () => server.NewNoticeList())); // Create task
        menuActions.Add(7, () => ExecuteIfSeniorOrPleno(isPleno, () => new MenuSubmitReviewTask().Execute(user))); // Submit task for review
        menuActions.Add(8, () => ExecuteIfSeniorOrPleno(isPleno, () => new MenuNewMeeting().Execute()));  // Schedule a meeting
        menuActions.Add(9, () => ExecuteIfSeniorOrPleno(isSenior, () => new MenuExitTask().Execute(user, noticeList))); // Delete note
        menuActions.Add(10, () => ExecuteIfSeniorOrPleno(isSenior, () => new MenuReviewTasks().Execute(user, noticeList))); // View tasks in review
        menuActions.Add(-1, () =>  // Exit option
        {
            Console.WriteLine("Goodbye!");
            Thread.Sleep(3000);
            new MenuLogin().Execute();  // Return to login menu
        });

        // Method to execute an action only if user is Senior or Pleno
        void ExecuteIfSeniorOrPleno(bool isSeniorOrPleno, Action action)
        {
            if (isSeniorOrPleno)
            {
                action();  // Execute action if authorized
            }
            else
            {
                Console.WriteLine("Invalid entry");
                Thread.Sleep(3000);  // Pause before refreshing
            }
        }

        // Method to display the menu and handle user input
        void ExecuteMenu()
        {
            Console.Clear();
            showTitle($"Your Task Options {user.Name}");  // Display user-specific title
            user.YourMeeting();  // Show user's meetings

            // Display basic options for all users
            Console.WriteLine($"\nEnter 1 to display {user.Type} group tasks");
            Console.WriteLine("Enter 2 to display your meetings");
            Console.WriteLine("Enter 3 to reset your password");

            // Display additional options for 'Pleno' users
            if (isPleno)
            {
                Console.WriteLine("Enter 4 to create a new user");
                Console.WriteLine("Enter 5 to delete a user");
                Console.WriteLine("Enter 6 to create a task");
                Console.WriteLine("Enter 7 to submit a task for review");
                Console.WriteLine("Enter 8 to schedule a meeting");
            }

            // Display additional options for 'Senior' users
            if (isSenior)
            {
                Console.WriteLine("Enter 9 to delete a note");
                Console.WriteLine("Enter 10 to view tasks under review");
            }

            Console.WriteLine("Enter -1 to Exit");  // Option to exit
            Console.Write("Enter your option: ");

            // Process user input
            string chosenOption = Console.ReadLine()!;
            if (int.TryParse(chosenOption, out int chosenOptionNumber))
            {
                // Execute the selected action if it exists
                if (menuActions.TryGetValue(chosenOptionNumber, out Action action))
                {
                    action();
                    ExecuteMenu();  // Redisplay menu after action
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    Thread.Sleep(3000);
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
                Thread.Sleep(3000);
            }
        }

        ExecuteMenu();  // Start the menu loop
    }
}