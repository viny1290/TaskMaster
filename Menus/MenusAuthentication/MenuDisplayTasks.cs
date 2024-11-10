using Models;

namespace Menus;

class MenuDisplayTasks
{
    // Method to display tasks associated with the user's group and provide options for task actions
    public void Execute(User user, List<Notice> noticeList)
    {
        // Check if there are any notices for the user's group
        if (noticeList.Count != 0)
        {
            bool exit = false;

            // Loop to display tasks until the user chooses to exit
            while (!exit)
            {
                Console.Clear();

                // Display tasks that are part of the user's group and not under review
                foreach (var notice in noticeList)
                {
                    if (notice.Group == user.Type)  // Check if task belongs to the user's group
                    {
                        if (notice.Progress != "Revisão")  // Exclude tasks under review
                        {
                            DateTime currentTime = DateTime.Now;
                            DateTime expectedEndDate = notice.Date.AddDays(notice.Term);
                            int daysRemaining = (expectedEndDate - currentTime).Days;

                            // Display task name and remaining days
                            Console.WriteLine($"Task: {notice.Name}, {daysRemaining} day(s) remaining until deadline");
                        }
                    }
                }

                // Display options for task actions
                Console.WriteLine("\nEnter 1 to Update a Task");
                Console.WriteLine("Enter 2 to View Task Details");
                Console.WriteLine("Enter -1 to Go Back");
                Console.Write("Enter your option: ");

                // Read and process user input for menu actions
                string chosenOption = Console.ReadLine()!;

                if (int.TryParse(chosenOption, out int chosenOptionNumber))
                {
                    switch (chosenOptionNumber)
                    {
                        case 1:
                            // Initialize the menu to update a task
                            MenuUpdatetask menuUpdatetask = new();
                            menuUpdatetask.Execute(user, noticeList);
                            break;
                        case 2:
                            // Initialize the menu to view task details
                            MenuTaskDetails menuTaskDetails = new();
                            menuTaskDetails.Execute(noticeList);
                            break;
                        case -1:
                            exit = true;  // Exit the loop and return to previous menu
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            Thread.Sleep(2000);  // Pause briefly to allow user to read message
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid entry");  // Display error for non-numeric input
                    Thread.Sleep(2000);
                }
            }
        }
        else
        {
            // Message displayed if there are no tasks for the user's group
            Console.WriteLine("Your team has no tasks");
        }

        Console.WriteLine("Press any key to return to the menu");  // Prompt to return to main menu
        Console.ReadKey();
    }
}