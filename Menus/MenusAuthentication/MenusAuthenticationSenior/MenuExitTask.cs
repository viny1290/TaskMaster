using Models;

namespace Menus;

class MenuExitTask
{
    // Method to display tasks and allow the user to delete a specific task
    public void Execute(User user, List<Notice> noticeList)
    {
        Console.Clear();

        // Display tasks related to the user's group and show days remaining for each task's deadline
        foreach (var notice in noticeList)
        {
            if (notice.Group == user.Type)
            {
                DateTime currentTime = DateTime.Now;
                DateTime deadline = notice.Date.AddDays(notice.Term);
                int daysRemaining = (deadline - currentTime).Days;
                Console.WriteLine($"Task: {notice.Name}, {daysRemaining} day(s) remaining until deadline");
            }
        }

        // Prompt user to enter the name of the task to delete
        Console.Write("Enter the name of the task: ");
        string taskName = Console.ReadLine()!;

        // Search for the task in the list by name
        Notice? taskToDelete = noticeList.FirstOrDefault(n => n.Name == taskName);

        // If the task is found, delete it from the list; otherwise, show an error message
        if (taskToDelete != null)
        {
            noticeList.Remove(taskToDelete);
            Console.WriteLine($"Task {taskName} successfully deleted.");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }
}
