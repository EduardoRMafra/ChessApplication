using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Generic;

namespace ChessApplication.Chess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position toPosision()
        {
            return new Position(8 - Line, Column - 'a');
        }
        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
