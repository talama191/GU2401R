namespace TicTacToe
{
    public abstract class Player
    {
        public Mark Marker { get; set; }

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
            //Xu ly viec di chuyen tren ban co nhu nao
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
