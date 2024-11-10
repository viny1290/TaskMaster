namespace Menus;
class Menu
{
    public void showTitle(string text)
    {
        int quantityNumbers= text.Length;
        string asterisks = string.Empty.PadLeft(quantityNumbers, '*');

        Console.WriteLine(asterisks);
        Console.WriteLine(text);
        Console.WriteLine(asterisks);
    }
}