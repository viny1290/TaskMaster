namespace Models;
class Meeting
{
    public Meeting(string name, string group, DateTime date)
    {
        Name = name;
        Group = group;
        Date = date;
    }

    public string Name { get; set; }
    public string Group { get; set; }
    public DateTime Date { get; set; }
}