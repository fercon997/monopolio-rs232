using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Monopolio_RS232.Logica
{
    class TaxSquare : Square
    {
        private int cobrar;

        public TaxSquare(string name, int posicionX, int posicionY, int cobrar) : base(name, posicionX, posicionY)
        {
            this.cobrar = cobrar;
        }

        public override int doAction(Player player, Board board)
        {
            player.getMoney().substractMoney(this.cobrar);

            if (player.getMoney().getMoney() < 0)
            {
                player.setBrokeOut(true);
            }

            // TODO: Ver que codigo deberiamos devolver
            return -1;
        }
    }
}
