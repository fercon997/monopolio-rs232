using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Monopolio_RS232.Logica
{
    class JailSquare: Square
    {
        public JailSquare(String name): base(name, 9, 360)
        {

        }

        public override void doAction(Player player, Board board)
        {
            Trace.WriteLine(player, player.getName() + " has been Jail and lost 500 money");
            player.getMoney().substractMoney(500);
        }
    }
}
