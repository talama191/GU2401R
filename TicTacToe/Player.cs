using System;

namespace TicTacToe
{
    public abstract class Player
    {
        public Mark Marker { get; private set; }

        protected Player(Mark marker)
        {
            Marker = marker;
        }

        public abstract void ProcessMove(Board board);
    }

    public class HumanPlayer : Player
    {
        public HumanPlayer(Mark marker) : base(marker)
        {
        }

        public override void ProcessMove(Board board)
        {
            int curCursorX = board.BoundaryX / 2;
            int curCursorY = board.BoundaryY / 2;

            bool placed = false;

            Console.SetCursorPosition(curCursorX, curCursorY);
            while (!placed)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (curCursorY > 0) curCursorY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (curCursorY < board.BoundaryY) curCursorY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (curCursorX > 0) curCursorX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (curCursorX < board.BoundaryX) curCursorX++;
                        break;
                    case ConsoleKey.Spacebar:
                        placed = board.PlaceMarker(curCursorX, curCursorY, Marker);
                        break;
                }
                Console.SetCursorPosition(curCursorX, curCursorY);
            }
        }
    }

    public class ComputerPlayer : Player
    {
        public ComputerPlayer(Mark marker) : base(marker)
        {
        }

        public override void ProcessMove(Board board)
        {
            //Tim 1 ngau nhien tren ban trong de dat con co
            (int, int) randomSlot = board.FindEmptySlotRandom();
            board.PlaceMarker(randomSlot.Item1, randomSlot.Item2, Marker);
        }
    }
}
