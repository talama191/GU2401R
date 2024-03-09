namespace TicTacToe
{
    public class Game
    {
        private Board board;
        private Player player1;
        private Player player2;

        private Player currentPlayer;

        public Game(Player player1, Player player2)
        {
            if (player1.Marker == player2.Marker) throw new System.Exception("2 nguoi choi khong duoc phep co con co giong nhau");
            this.player1 = player1;
            this.player2 = player2;

            board = new Board();
            currentPlayer = player1;
        }

        public void Start()
        {
            bool isGameOver = false;

            while (isGameOver)
            {
                if (board.IsGameOver()) return;
                currentPlayer.ProcessMove(board);
                currentPlayer = currentPlayer == player1 ? player2 : player1;

            }
        }
    }
}
