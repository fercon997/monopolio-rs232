using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Monopolio_RS232.Logica
{
    class GoToJailSquare: Square
    {
        public GoToJailSquare(String name) : base(name, 360, 9)
        {
        }

        public override int doAction(Player player, Board board)
        {
            Trace.WriteLine(player, player.getName() + "has go to Jail");
            board.movePlayer(player, -board.getTotalSquare() / 2, false);
            return 0;
        }
    }
}
