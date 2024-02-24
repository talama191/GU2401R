
public class Program
{
    static void Main(string[] args)
    {
        int count = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < count; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("O");
            }
            count++;
        }
        int x = 0;
        int y = 3;
        Console.SetCursorPosition(x, y);

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.UpArrow && y > 0)
            {
                y--;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                y++;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow && x > 0)
            {
                x--;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                x++;
            }
            Console.SetCursorPosition(x, y);
        }
    }
}