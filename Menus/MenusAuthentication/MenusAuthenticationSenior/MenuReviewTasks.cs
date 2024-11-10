using Models;

namespace Menus;

class MenuReviewTasks
{
    // Method to allow the user to review tasks and finalize or return them
    public void Execute(User user, List<Notice> noticeList)
    {
        if (noticeList.Count != 0) // Check if there are tasks to review
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                // Display tasks that are under review for the user's group
                foreach (var notice in noticeList)
                {
                    if (notice.Group == user.Type)
                    {
                        if (notice.Progress == "Revisão") // Only show tasks in the "Revisão" status
                        {
                            DateTime currentTime = DateTime.Now;
                            DateTime deadline = notice.Date.AddDays(notice.Term);
                            int daysRemaining = (deadline - currentTime).Days;
                            Console.WriteLine($"Task: {notice.Name}, {daysRemaining} day(s) remaining until deadline");
                        }
                    }
                }

                // Display menu options for reviewing tasks
                Console.WriteLine("\nEnter 1 to finalize a task");
                Console.WriteLine("Enter 2 to return a task for further work");
                Console.WriteLine("Enter -1 to go back");
                Console.Write("Enter your option: ");

                string chosenOption1 = Console.ReadLine()!;

                // Handle user input and execute corresponding actions
                if (int.TryParse(chosenOption1, out int chosenOptionNumber1))
                {
                    switch (chosenOptionNumber1)
                    {
                        case 1: // Finalize a task
                            Console.Write("Enter the name of the task to finalize: ");
                            string taskName = Console.ReadLine()!;
                            Notice? taskToFinalize = noticeList.FirstOrDefault(u => u.Name == taskName);

                            if (taskToFinalize != null)
                            {
                                noticeList.Remove(taskToFinalize); // Remove task from the list
                                Console.WriteLine($"Task {taskName} finalized.");
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }
                            Thread.Sleep(3000); // Pause for 3 seconds
                            break;

                        case 2: // Return a task for further updates
                            Console.Write("Enter the name of the task to update: ");
                            string taskToUpdateName = Console.ReadLine()!;
                            Notice? taskToUpdate = noticeList.FirstOrDefault(u => u.Name == taskToUpdateName);

                            if (taskToUpdate != null)
                            {
                                Console.Write("Enter your update: ");
                                string updateText = Console.ReadLine()!;

                                taskToUpdate.NewUpdate(user.Name, updateText, "Development"); // Add a new update to the task
                                Console.WriteLine("Task updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Task not found.");
                            }
                            Thread.Sleep(3000); // Pause for 3 seconds
                            break;

                        case -1: // Exit the loop and return to the main menu
                            exit = true;
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        else
        {
            Console.WriteLine("Your team has no tasks.");
        }

        // Prompt user to press any key to go back to the menu
        Console.WriteLine("Press any key to go back to the menu.");
        Console.ReadKey();
    }
}
