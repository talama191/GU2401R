

public class SnakeProgram
{
    static void Test()
    {
        int maxWidth = 5;
        int maxHeight = 5;
        Console.Clear();
        for (int i = 0; i <= maxWidth + 1; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.SetCursorPosition(i, maxHeight + 1);
            Console.Write("#");
        }

        for (int i = 0; i < maxHeight + 1; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("#");
            Console.SetCursorPosition(maxWidth + 1, i);
            Console.Write("#");
        }
        Console.BackgroundColor = ConsoleColor.Black;

        int middleX = (maxWidth / 2) + 1;
        int middleY = (maxHeight / 2) + 1;

        Console.SetCursorPosition(middleX, middleY);
        Console.Write("O");
        int currentX = middleX;
        int currentY = middleY;

        while (true)
        {
            Console.SetCursorPosition(currentX, currentY);

            ConsoleKeyInfo userKey = Console.ReadKey();
            Console.Write(" ");
            switch (userKey.Key)
            {
                case ConsoleKey.UpArrow:
                    currentY--;
                    break;
                case ConsoleKey.DownArrow:
                    currentY++;
                    break;
                case ConsoleKey.LeftArrow:
                    currentX--;
                    break;
                case ConsoleKey.RightArrow:
                    currentX++;
                    break;
            }
            Console.SetCursorPosition(currentX, currentY);
            Console.Write("O");

            //todo
            if (currentX == 0)
            {
                break;
            }
        }
        Console.Clear();
        Console.WriteLine("Game over");
        Console.ReadKey();
    }
}
