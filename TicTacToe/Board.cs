namespace TicTacToe
{
    public class Board
    {
        private Mark[,] grid;

        public Board()
        {
            grid = new Mark[3, 3];
        }

        public void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = Mark.Empty;
                }
            }
        }

        public bool IsEmpty(int row, int col)
        {
            return grid[row, col] == Mark.Empty;
        }

        public bool PlaceMarker(int row, int col, Mark mark)
        {
            if (!IsEmpty(row, col)) return false;
            grid[row, col] = mark;
            return true;
        }

        public bool IsGameOver()
        {
            //check xem ban co full chua hay la hang cheo, hang doc, hang ngang co cung 1 loai co
            throw new System.NotImplementedException();
        }

        public Mark GetWinner()
        {
            throw new System.NotImplementedException();
        }
    }

    public enum Mark
    {
        X,
        O,
        Empty
    }
}
