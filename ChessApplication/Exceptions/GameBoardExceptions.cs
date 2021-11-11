using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApplication.Exceptions
{
    class GameBoardExceptions : ApplicationException
    {
        public GameBoardExceptions(string msg) : base(msg)
        {

        }
    }
}
