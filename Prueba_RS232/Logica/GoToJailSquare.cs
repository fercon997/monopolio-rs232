using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Monopolio_RS232.Logica
{
    class GoToJailSquare: Square
    {
        public GoToJailSquare(String name) : base(name, 385, 34)
        {
        }

        public override void doAction(Player player, Board board)
        {
            Trace.WriteLine(player, player.getName() + "has go to Jail");
            board.movePlayer(player, -board.getTotalSquare() / 2, false);
        }
    }
}
