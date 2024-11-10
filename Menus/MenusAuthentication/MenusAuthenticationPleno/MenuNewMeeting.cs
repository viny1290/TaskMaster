using Models;
using Server;

namespace Menus;

class MenuNewMeeting
{
    // Method to create and schedule a new meeting
    public void Execute()
    {
        Server1 server = new();
        List<User> userList = server.ReturnListUser(); // Retrieve the list of users from the server

        Console.Clear(); // Clear the console
        Console.Write("Enter the meeting name: ");
        string meetingName = Console.ReadLine()!;
        Console.Write("Enter in how many days the meeting will take place: ");
        string meetingDay = Console.ReadLine()!;

        // Parse the input to determine the meeting day
        if (int.TryParse(meetingDay, out int meetingDayValue))
        {
            DateTime currentTime = DateTime.Now;
            DateTime expectedDate = currentTime.Date.AddDays(meetingDayValue); // Calculate the meeting date

            // Ask the user to specify the group for the meeting
            Console.WriteLine("Enter 1 for Back-End");
            Console.WriteLine("Enter 2 for Front-End");
            Console.WriteLine("Enter 3 for All");
            Console.Write("Enter the group that will have the meeting: ");
            string meetingType = Console.ReadLine()!;

            // Set the group based on user input
            string group = meetingType switch
            {
                "1" => "Back-End",
                "2" => "Front-End",
                "3" => "All",
                _ => ""
            };

            // Validate the group input
            if (string.IsNullOrEmpty(group))
            {
                Console.WriteLine("Invalid input for the task group.");
            }
            else
            {
                // Create a new meeting
                Meeting newMeeting = new Meeting(meetingName, group, expectedDate);

                // Assign the meeting to the relevant users based on the group
                if (group != "All")
                {
                    foreach (User u in userList)
                    {
                        if (u.Type == group)
                        {
                            u.AddMeeting(newMeeting); // Add the meeting to the user's calendar
                        }
                    }
                }
                else
                {
                    foreach (User u in userList)
                    {
                        u.AddMeeting(newMeeting); // Add the meeting to all users' calendars
                    }
                }
            }

            // Confirm meeting creation
            Console.WriteLine($"Meeting {meetingName} created and sent to everyone.");
            Console.WriteLine($"Press any key to return to the menu.");
            Console.ReadKey();
        }
        else
        {
            // Handle invalid input
            Console.WriteLine("Invalid input.");
            Thread.Sleep(3000); // Pause for 3 seconds
        }
    }
}