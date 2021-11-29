using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Generic;
using ChessApplication.Exceptions;

namespace ChessApplication.Chess
{
    class ChessGame
    {
        public GameBoard GameB { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }
        public bool Check { get; private set; }
        HashSet<Piece> Pieces;
        HashSet<Piece> Captured;

        public ChessGame()
        {
            GameB = new GameBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Check = false;

            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PiecesToPlace();
        }
        Piece MovePiece(Position initial, Position destination)
        {
            Piece p = GameB.RemovePiece(initial);
            p.IncreaseQtMoves();
            Piece capturedPiece = GameB.RemovePiece(destination);
            GameB.PieceToPlace(p, destination);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }
        public void UndoMove(Position initial, Position destination,Piece capturedPiece)
        {
            Piece p = GameB.RemovePiece(destination);
            p.DecreaseQtMoves();
            if(capturedPiece != null)
            {
                GameB.PieceToPlace(capturedPiece,destination);
                Captured.Remove(capturedPiece);
            }
            GameB.PieceToPlace(p, initial);
        }
        public void MakeMovement(Position initial, Position destination)
        {
            Piece capturedPiece = MovePiece(initial, destination);

            Piece p = GameB.piece(destination);

            Turn++;
            ChangePlayer();
        }
        public void InitialPositionIsValid(Position pos)
        {
            GameB.ValidPosition(pos);

            if (GameB.piece(pos) == null)
            {
                throw new GameBoardExceptions("Has no piece in this position!");
            }
            if (CurrentPlayer != GameB.piece(pos).Color)
            {
                throw new GameBoardExceptions("This piece isn't yours!");
            }
            if (!GameB.piece(pos).HasPosibleMoves())
            {
                throw new GameBoardExceptions("Has no posible moves for this piece!");
            }
        }
        public void DestinationPositionIsValid(Position Initial, Position Destination)
        {
            if (!GameB.piece(Initial).PosibleMove(Destination))
            {
                throw new GameBoardExceptions("Invalid position!");
            }
        }
        void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
        public void PutNewPieces(char c, int l, Piece p)
        {
            GameB.PieceToPlace(p, new ChessPosition(c, l).toPosision());
            Pieces.Add(p);
        }
        void PiecesToPlace()
        {
            //Peças Brancas
            PutNewPieces('a', 1, new Tower(GameB, Color.White));
            PutNewPieces('b', 1, new Horse(GameB, Color.White));
            PutNewPieces('c', 1, new Bishop(GameB, Color.White));
            PutNewPieces('d', 1, new Queen(GameB, Color.White));
            PutNewPieces('e', 1, new King(GameB, Color.White));
            PutNewPieces('f', 1, new Bishop(GameB, Color.White));
            PutNewPieces('g', 1, new Horse(GameB, Color.White));
            PutNewPieces('h', 1, new Tower(GameB, Color.White));
            PutNewPieces('a', 2, new Pawn(GameB, Color.White));
            PutNewPieces('b', 2, new Pawn(GameB, Color.White));
            PutNewPieces('c', 2, new Pawn(GameB, Color.White));
            PutNewPieces('d', 2, new Pawn(GameB, Color.White));
            PutNewPieces('e', 2, new Pawn(GameB, Color.White));
            PutNewPieces('f', 2, new Pawn(GameB, Color.White));
            PutNewPieces('g', 2, new Pawn(GameB, Color.White));
            PutNewPieces('h', 2, new Pawn(GameB, Color.White));
            //Peças Pretas
            PutNewPieces('a', 8, new Tower(GameB, Color.Black));
            PutNewPieces('b', 8, new Horse(GameB, Color.Black));
            PutNewPieces('c', 8, new Bishop(GameB, Color.Black));
            PutNewPieces('d', 8, new Queen(GameB, Color.Black));
            PutNewPieces('e', 8, new King(GameB, Color.Black));
            PutNewPieces('f', 8, new Bishop(GameB, Color.Black));
            PutNewPieces('g', 8, new Horse(GameB, Color.Black));
            PutNewPieces('h', 8, new Tower(GameB, Color.Black));
            PutNewPieces('a', 7, new Pawn(GameB, Color.Black));
            PutNewPieces('b', 7, new Pawn(GameB, Color.Black));
            PutNewPieces('c', 7, new Pawn(GameB, Color.Black));
            PutNewPieces('d', 7, new Pawn(GameB, Color.Black));
            PutNewPieces('e', 7, new Pawn(GameB, Color.Black));
            PutNewPieces('f', 7, new Pawn(GameB, Color.Black));
            PutNewPieces('g', 7, new Pawn(GameB, Color.Black));
            PutNewPieces('h', 7, new Pawn(GameB, Color.Black));
        }
    }
}
