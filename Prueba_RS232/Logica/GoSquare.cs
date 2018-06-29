using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Monopolio_RS232.Logica
{
    class GoSquare: Square
    {
        public GoSquare(String name) : base(name)
        {
           
        }

        public override void doAction(Player player, Board board)
        {
            Trace.WriteLine(player, player.getName() + " is at Go... Giving 1000 money");
            player.getMoney().addMoney(1000);
        }
    }
}
