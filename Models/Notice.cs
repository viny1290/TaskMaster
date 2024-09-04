namespace Models;
class Notice
{
    Dictionary<String, String> Updates = new();
    public Notice(string name, string progress, string group, DateTime date, int term)
    {
        Name = name;
        Progress = progress;
        Group = group;
        Date = date;
        Term = term;
    }

    public string Name { get; }
    public string Progress { get; private set; }
    public String Group { get; }
    public DateTime Date { get; }
    public int Term { get; private set; }

    public void NoticeUpdates()
    {
        if (Updates.Count != 0)
        {
            foreach (var nota in Updates)
            {
                Console.WriteLine($"Data: {nota.Key}, {(Progress == "Criado" ? $"foi {Progress}" : $"Esta em {Progress}")}, {nota.Value}");
            }
        }
        else
        {
            Console.WriteLine($"Criado em {Date.Date}");
        }
    }

    public void NewUpdate(string name, string texto, string taskProgress)
    {
        DateTime dateCurrentTime = DateTime.Now;
        string formattedDate = dateCurrentTime.ToString("dd/MM/yyyy HH:mm");
        Progress = taskProgress;

        Updates.Add(formattedDate, $"{name}: {texto}");
    }
}