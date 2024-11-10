using Models;

namespace Menus;

class MenuTaskDetails
{
    // Method to display details of a specific task
    public void Execute(List<Notice> noticeList)
    {
        // Prompt the user to enter the name of the task to view details
        Console.Write("Enter the name of the task to view details: ");
        string taskName = Console.ReadLine()!;

        // Search for the task in the list by name
        Notice? notice = noticeList.FirstOrDefault(n => n.Name == taskName);

        // If the task is found, display its details; otherwise, show an error message
        if (notice != null)
        {
            notice.NoticeUpdates();  // Display updates for the selected task
        }
        else
        {
            Console.WriteLine("Task not found.");  // Error message if task is not found
        }

        // Prompt to return to the previous menu
        Console.WriteLine("\nPress any key to return to the menu");
        Console.ReadKey();
    }
}