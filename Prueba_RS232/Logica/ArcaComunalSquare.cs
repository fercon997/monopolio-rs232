using System;
using System.Collections.Generic;
using System.Text;

namespace Monopolio_RS232.Logica
{
    public class ArcaComunalSquare : Square
    {
        private Random random;
        public ArcaComunalSquare(string nombre, Random random): base(nombre)
        {
            this.random = random;
        }

        public override void doAction(Player player, Board board)
        {
            int r = random.Next(0, 16);

            switch (r)
            {
                // El jugador paga $50 a cada jugador
                case 0:
                    if (player.getMoney().getMoney() < 50*board.getPlayers().Length)
                    {
                        // No tiene suficiente para pagar, me imagino que
                        // quiebra y ya
                        player.setBrokeOut(true);
                    } else
                    {
                        // Recorremos los jugadores y pagamos 50 a cada uno
                        foreach(var jugador in board.getPlayers())
                        {
                            if (jugador.getID() != player.getID())
                            {
                                player.getMoney().substractMoney(50);
                                jugador.getMoney().addMoney(50);
                            }
                        }
                    }
                    break;

                // El jugador va a la carcel
                case 1:
                    player.GoToJail();
                    break;

                // Jugador puede salir gratis de la carcel
                case 2:
                    player.GiveJailPass();
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;

                case 7:
                    break;

                case 8:
                    break;

                case 9:
                    break;

                case 10:
                    break;

                case 11:
                    break;

                case 12:
                    break;

                case 13:
                    break;

                case 14:
                    break;

                case 15:
                    break;
            }
        }
    }
}
