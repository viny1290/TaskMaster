using Models;
using Server;

namespace Menus;

class MenuSubmitReviewTask
{
    // Method to send a task for review
    public void Execute(User user)
    {
        Server1 server = new();
        List<Notice> listNotice = server.ReturnListNotice(); // Retrieve the list of tasks from the server
        if (listNotice.Count != 0)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear(); // Clear the console
                foreach (var notice in listNotice)
                {
                    if (notice.Group == user.Type) // Check if the task belongs to the user's group
                    {
                        if (notice.Progress == "Development") // Only show tasks in the "Development" stage
                        {
                            DateTime time = DateTime.Now;
                            DateTime expectedDate = notice.Date.AddDays(notice.Term); // Calculate the expected date of the task
                            int daysRemaining = (expectedDate - time).Days; // Calculate the remaining days
                            Console.WriteLine($"Task: {notice.Name}, {daysRemaining} day(s) remaining until the deadline");
                        }
                    }
                }

                // Provide options for the user
                Console.WriteLine("\nEnter 1 to send a task for review");
                Console.WriteLine("Enter -1 to go back");
                Console.Write("Enter your option: ");
                string chosenOption = Console.ReadLine()!;

                // Handle the user's choice
                if (int.TryParse(chosenOption, out int chosenOptionNumber))
                {
                    switch (chosenOptionNumber)
                    {
                        case 1:
                            // User wants to send a task for review
                            Console.Write("Enter the name of the task to update: ");
                            string taskName = Console.ReadLine()!;
                            Notice? taskToReview = listNotice.FirstOrDefault(u => u.Name == taskName);

                            if (taskToReview != null)
                            {
                                // Update task progress to "Review"
                                taskToReview.NewUpdate(user.Name, "Finished", "Review");
                                Console.WriteLine("Task successfully sent for review");
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }
                            Thread.Sleep(3000); // Wait for 3 seconds before proceeding
                            break;
                        case -1:
                            // User chooses to exit
                            exit = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        else
        {
            // No tasks available for the user's group
            Console.WriteLine("Your team has no tasks");
        }

        // Prompt to return to the menu
        Console.WriteLine($"Press any key to return to the menu");
        Console.ReadKey();
    }
}
