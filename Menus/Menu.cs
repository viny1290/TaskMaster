namespace Menus;
class Menu
{
    public void showTitle(string titulo)
    {
        int quantityNumbers= titulo.Length;
        string asterisks = string.Empty.PadLeft(quantityNumbers, '*');

        Console.WriteLine(asterisks);
        Console.WriteLine(titulo);
        Console.WriteLine(asterisks);
    }
}