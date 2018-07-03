using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Monopolio_RS232.Logica
{
    class VacationSquare: Square
    {
        public VacationSquare(String name): base(name, 9, 9)
         {

        }

        public override int doAction(Player player, Board board)
        {
            Random rand = new Random();
            Square square = board.movePlayer(player, rand.Next(board.getTotalSquare()), false);
            Trace.WriteLine(player, player.getName() + " has go to vacation at " + square.getName());
            return 0;
        }
    }
}
