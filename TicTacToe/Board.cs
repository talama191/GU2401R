using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
        private Mark[,] grid;

        public int BoundaryX => grid.GetLength(0) - 1;
        public int BoundaryY => grid.GetLength(1) - 1;

        public Mark WinnerMark { get; private set; }

        public Board()
        {
            grid = new Mark[3, 3];
            WinnerMark = Mark.Empty;
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = Mark.Empty;
                }
            }
        }

        public bool IsEmpty(int row, int col)
        {
            return grid[row, col] == Mark.Empty;
        }

        public (int, int) FindEmptySlotRandom()
        {
            List<(int, int)> emptySlots = FindEmptySlotsRandom();

            if (emptySlots.Count > 0)
            {
                Random rd = new Random();
                int randomIndex = rd.Next(0, emptySlots.Count);
                return emptySlots[randomIndex];
            }

            return default;
        }

        private List<(int, int)> FindEmptySlotsRandom()
        {
            List<(int, int)> emptySlots = new List<(int, int)>();

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (IsEmpty(i, j))
                    {
                        emptySlots.Add((i, j));
                    }
                }
            }
            return emptySlots;
        }

        public bool PlaceMarker(int row, int col, Mark mark)
        {
            if (!IsEmpty(row, col)) return false;
            grid[row, col] = mark;
            Console.SetCursorPosition(row, col);
            Console.Write(MarkToChar(mark));
            return true;
        }

        public bool CheckGameOver()
        {
            //check hang ngang va doc
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Mark? currentMark = null;
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        currentMark = null;
                    }
                    if (currentMark == null)
                    {
                        currentMark = grid[i, j];
                    }
                    else
                    {
                        if (currentMark != grid[i, j])
                        {
                            break;
                        }
                    }
                    if (grid[i, j] == Mark.Empty)
                    {
                        break;
                    }
                    if (j == grid.GetLength(0) - 1)
                    {
                        WinnerMark = (Mark)currentMark;
                        return true;
                    }
                }
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Mark? currentMark = null;
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        currentMark = null;
                    }
                    if (currentMark == null)
                    {
                        currentMark = grid[j, i];
                    }
                    else
                    {
                        if (currentMark != grid[j, i])
                        {
                            break;
                        }
                    }
                    if (grid[j, i] == Mark.Empty)
                    {
                        break;
                    }
                    if (j == grid.GetLength(0) - 1)
                    {
                        WinnerMark = (Mark)currentMark;
                        return true;
                    }
                }
            }
            //check duong cheo
            Mark? currentMarkCheo = null;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (currentMarkCheo == null)
                {
                    currentMarkCheo = grid[i, i];
                }
                else
                {
                    if (currentMarkCheo != grid[i, i])
                    {
                        break;
                    }
                }
                if (grid[i, i] == Mark.Empty)
                {
                    break;
                }
                if (i == grid.GetLength(0) - 1)
                {
                    WinnerMark = (Mark)currentMarkCheo;
                    return true;
                }
            }
            if (FindEmptySlotsRandom().Count == 0)
            {
                return true;
            }
            return false;
        }

        public Player GetWinner()
        {
            throw new System.NotImplementedException();
        }

        public char MarkToChar(Mark mark)
        {
            switch (mark)
            {
                case Mark.X:
                    return 'x';
                case Mark.O:
                    return 'o';
                case Mark.Empty:
                    return ' ';
            }
            return default;
        }
    }

    public enum Mark
    {
        X,
        O,
        Empty
    }
}
