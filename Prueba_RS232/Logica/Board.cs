using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Monopolio_RS232.Logica
{
    class Board
    {
        int currentTurn = 0;
        int totalPlayer = 0;
        Player[] players;
        Square[] squares = new Square[40];
        String[] names = new String[] { "House", "Villa", "Town", "City", "Peace", "Village", "Jade", "Soi 4", "White", "Dark" };

        public Board(int totalPlayer)
        {
            players = new Player[totalPlayer];
            this.totalPlayer = totalPlayer;
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player(i, "Player " + (i + 1));
            }
            Random rand = new Random();
            for (int i = 0; i < squares.Length; i++)
            {
                if (i == 0)
                {
                    squares[i] = new GoSquare("GO");
                }
                else if (i == 9)
                {
                    //squares[i] = new JailSquare("Jail");
                }
                else if (i == 19)
                {
                    //squares[i] = new VacationSquare("Vacation");
                }
                else if (i == 29)
                {
                    //squares[i] = new GoToJailSquare("Go to Jail");
                }
                else
                {
                    // TODO: Pila aqui en como ua el random, este es el de Java. Hay que pasarlo al de C#
                    //squares[i] = new HouseSquare(names[rand.nextInt(names.Length)] + " " + names[rand.nextInt(names.Length)], 400 + rand.nextInt(300));
                }
            }
        }

        public Square movePlayer(Player player, int face)
        {
            return movePlayer(player, face, true);
        }

        public Square movePlayer(Player player, int face, bool count)
        {
            if (player.isBrokeOut()) { return squares[player.getCurrentPosition()]; }
            int newPosition = normalizePosition(player.getCurrentPosition() + face);
            player.setPosition(newPosition);
            Trace.WriteLine(player, player.getName() + " goes to " + squares[player.getCurrentPosition()].getName());
            squares[newPosition].doAction(player, this);
            if (player.getMoney().isBrokeOut())
            {
                Trace.WriteLine(player, player.getName() + " has been broke out!");
                player.setBrokeOut(true);
            }
            else
            {
                if (count)
                {
                    player.nextTurn();
                }
            }
            return squares[newPosition];
        }

        public bool hasWinner()
        {
            int ingame = 0;
            foreach (Player player in players)
            {
                if (!player.isBrokeOut())
                {
                    ingame++;
                }
            }
            return ingame <= 1;
        }

        public Player getWinner()
        {
            if (!hasWinner()) { return null; }
            foreach (Player player in players)
            {
                if (!player.isBrokeOut()) { return player; }
            }
            return null;
        }

        public Player getMaxMoneyPlayer()
        {
            Player maxplayer = null;
            foreach (Player player in players)
            {
                if (maxplayer == null || maxplayer.getMoney().getMoney() < player.getMoney().getMoney())
                {
                    maxplayer = player;
                }
            }
            return maxplayer;
        }

        public int normalizePosition(int position)
        {
            return position % squares.Length;
        }

        public Player getCurrentPlayer()
        {
            return players[currentTurn];
        }

        public Player[] getPlayers()
        {
            return players;
        }

        public void nextTurn()
        {
            if (++currentTurn >= players.Length)
            {
                currentTurn = 0;
            }
        }

        public Player getPlayer(int id)
        {
            return players[id];
        }

        public int getTotalSquare()
        {
            return squares.Length;
        }
    }
}
