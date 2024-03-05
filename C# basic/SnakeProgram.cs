

public class SnakeProgram
{
    public static void Test()
    {
        int score = 0;
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

        //luu tru nhung toa do bi chiem
        bool[,] grid = new bool[maxWidth + 2, maxHeight + 2];
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            grid[0, i] = true;
            grid[maxWidth + 1, i] = true;
        }
        for (int i = 0; i < grid.GetLength(1); i++)
        {
            grid[i, 0] = true;
            grid[i, maxHeight + 1] = true;
        }
        grid[currentX, currentY] = true;

        int currentFoodX = 0;
        int currentFoodY = 0;
        SpawnFood(grid, maxWidth, maxHeight, out int x, out int y);
        currentFoodX = x;
        currentFoodY = y;
        Console.SetCursorPosition(x, y);
        Console.Write("X");

        bool isPlaying = true;
        while (isPlaying)
        {
            Console.SetCursorPosition(currentX, currentY);

            ConsoleKeyInfo userKey = Console.ReadKey();
            Console.Write(" ");
            grid[currentX, currentY] = false;
            //xu li di chuyen
            switch (userKey.Key)
            {
                case ConsoleKey.UpArrow:
                    currentY--;
                    if (currentY == 0) isPlaying = false;
                    break;
                case ConsoleKey.DownArrow:
                    currentY++;
                    if (currentY == maxHeight + 1) isPlaying = false;
                    break;
                case ConsoleKey.LeftArrow:
                    currentX--;
                    if (currentX == 0) isPlaying = false;
                    break;
                case ConsoleKey.RightArrow:
                    currentX++;
                    if (currentX == maxWidth + 1) isPlaying = false;
                    break;
            }
            grid[currentX, currentY] = true;
            Console.SetCursorPosition(currentX, currentY);
            Console.Write("O");

            //Khi ran an moi
            if (currentX == currentFoodX && currentY == currentFoodY)
            {
                //spawn moi moi
                SpawnFood(grid, maxWidth, maxHeight, out int newX, out int newY);
                Console.SetCursorPosition(currentFoodX, currentFoodY);
                Console.Write(" ");
                currentFoodX = newX;
                currentFoodY = newY;
                Console.SetCursorPosition(currentFoodX, currentFoodY);
                Console.Write("X");

                //ve lai chu ran
                Console.SetCursorPosition(currentX, currentY);
                Console.Write("O");
                score++;
            }

            if (currentX == 0)
            {
                break;
            }
        }
        Console.Clear();
        Console.WriteLine($"Game over, score:{score}");
        Console.ReadKey();
    }

    public static void SpawnFood(bool[,] grid, int width, int height, out int x, out int y)
    {
        int unoccupiedCount = (width + 2) * (height + 2) - (width + 2) * 2 - height * 2 - 1;
        int[] xValues = new int[unoccupiedCount];
        int[] yValues = new int[unoccupiedCount];

        int index = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (!grid[i, j])
                {
                    xValues[index] = i;
                    yValues[index] = j;
                    index++;
                }
            }
        }
        Random rd = new Random();
        int randomIndex = rd.Next(0, unoccupiedCount);

        x = xValues[randomIndex];
        y = yValues[randomIndex];
    }
}
