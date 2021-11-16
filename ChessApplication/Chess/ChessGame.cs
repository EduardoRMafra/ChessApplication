using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class ChessGame
    {
        public GameBoard BoardG { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finish { get; private set; }
        public bool Check { get; private set; }
        HashSet<Piece> Pieces;
        HashSet<Piece> Captured;

        public ChessGame()
        {
            BoardG = new GameBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finish = false;
            Check = false;

            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PiecesToPlace();
        }
        public void PutNewPieces(char c, int l, Piece p)
        {
            BoardG.PieceToPlace(p, new ChessPosition(c, l).toPosision());
            Pieces.Add(p);
        }
        void PiecesToPlace()
        {
            //Peças Brancas
            PutNewPieces('a', 1, new Tower(BoardG, Color.White));
            PutNewPieces('b', 1, new Horse(BoardG, Color.White));
            PutNewPieces('c', 1, new Bishop(BoardG, Color.White));
            PutNewPieces('d', 1, new Queen(BoardG, Color.White));
            PutNewPieces('e', 1, new King(BoardG, Color.White));
            PutNewPieces('f', 1, new Bishop(BoardG, Color.White));
            PutNewPieces('g', 1, new Horse(BoardG, Color.White));
            PutNewPieces('h', 1, new Tower(BoardG, Color.White));
            PutNewPieces('a', 2, new Pawn(BoardG, Color.White));
            PutNewPieces('b', 2, new Pawn(BoardG, Color.White));
            PutNewPieces('c', 2, new Pawn(BoardG, Color.White));
            PutNewPieces('d', 2, new Pawn(BoardG, Color.White));
            PutNewPieces('e', 2, new Pawn(BoardG, Color.White));
            PutNewPieces('f', 2, new Pawn(BoardG, Color.White));
            PutNewPieces('g', 2, new Pawn(BoardG, Color.White));
            PutNewPieces('h', 2, new Pawn(BoardG, Color.White));
            //Peças Pretas
            PutNewPieces('a', 8, new Tower(BoardG, Color.Black));
            PutNewPieces('b', 8, new Horse(BoardG, Color.Black));
            PutNewPieces('c', 8, new Bishop(BoardG, Color.Black));
            PutNewPieces('d', 8, new Queen(BoardG, Color.Black));
            PutNewPieces('e', 8, new King(BoardG, Color.Black));
            PutNewPieces('f', 8, new Bishop(BoardG, Color.Black));
            PutNewPieces('g', 8, new Horse(BoardG, Color.Black));
            PutNewPieces('h', 8, new Tower(BoardG, Color.Black));
            PutNewPieces('a', 7, new Pawn(BoardG, Color.Black));
            PutNewPieces('b', 7, new Pawn(BoardG, Color.Black));
            PutNewPieces('c', 7, new Pawn(BoardG, Color.Black));
            PutNewPieces('d', 7, new Pawn(BoardG, Color.Black));
            PutNewPieces('e', 7, new Pawn(BoardG, Color.Black));
            PutNewPieces('f', 7, new Pawn(BoardG, Color.Black));
            PutNewPieces('g', 7, new Pawn(BoardG, Color.Black));
            PutNewPieces('h', 7, new Pawn(BoardG, Color.Black));
        }
    }
}
