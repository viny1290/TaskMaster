using Models;

namespace Menus;

class MenuUpdatetask
{
    // Method to update a specific task with a new update from the user
    public void Execute(User user, List<Notice> noticeList)
    {
        // Prompt the user to enter the name of the task to update
        Console.Write("Enter the name of the task to update: ");
        string taskName = Console.ReadLine()!;
        
        // Search for the task in the list by name
        Notice? notice = noticeList.FirstOrDefault(n => n.Name == taskName);

        // If the task is found, prompt for an update message; otherwise, display an error
        if (notice != null)
        {
            Console.Write("Enter your update: ");
            string updateText = Console.ReadLine()!;

            // Record the new update with the user's name, update text, and status as "Development"
            notice.NewUpdate(user.Name, updateText, "Development");

            Console.WriteLine("Task updated successfully.");
        }
        else
        {
            Console.WriteLine("Task not found.");  // Error message if task is not found
        }

        // Pause briefly to allow user to read message
        Thread.Sleep(3000);
    }
}
