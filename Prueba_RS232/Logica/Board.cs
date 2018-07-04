using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;

namespace Monopolio_RS232.Logica
{
    public class Board
    {
        int currentTurn = 0;
        int totalPlayer = 0;
        int dobles = 0;
        Player[] players;
        Square[] squares = new Square[40];
        Dictionary<int, int> posicionXCasualidades = new Dictionary<int, int>()
        {
            {3, 217},
            {8, 118},
            {18, 9},
            {23, 85},
            {34, 360},
            {37, 360}
        };
        Dictionary<int, int> posicionYCasualidades = new Dictionary<int, int>()
        {
            {3, 360},
            {8, 360},
            {18, 117},
            {23, 9},
            {34, 118},
            {37, 217}
        };
        Dictionary<int, String> houseBits = new Dictionary<int, string>() {
            {1, "00000"},
            {3, "00001"},
            {5, "11000"},
            {6, "00010"},
            {8, "00011"},
            {9, "00100"},
            {11, "00101"},
            {12, "10110"},
            {13, "00110"},
            {14, "00111"},
            {15, "11001"},
            {16, "01000"},
            {18, "01001"},
            {19, "01010"},
            {21, "01011"},
            {23, "01100"},
            {24, "01101"},
            {25, "11010"},
            {26, "01110"},
            {27, "01111"},
            {28, "10111"},
            {29, "10000"},
            {31, "10001"},
            {32, "10010"},
            {34, "10011"},
            {35, "11011"},
            {37, "10100"},
            {39, "10101"}
        };

        public Board()
        {
            var propiedades = PropiedadFactory.GenerarTableroDeArchivo(Properties.Resources.Propiedades);
            for (int i = 0; i < squares.Length; i++)
            {
                if (i == 0)
                {
                    squares[i] = new GoSquare("GO");
                }
                else if (i == 10)
                {
                    squares[i] = new JailSquare("Jail");
                }
                else if (i == 20)
                {
                    squares[i] = new VacationSquare("Vacation");
                }
                else if (i == 30)
                {
                    squares[i] = new GoToJailSquare("Go to Jail");
                }
                else
                {
                    if (propiedades.ContainsKey(i+1))
                    {
                        squares[i] = propiedades[i + 1];
                    }
                    else
                    {
                        // Arca Comunal, Chance
                        // TODO: Implementar esto correctamente, deberian tener
                        //       su propia clase que en el doAction eliga algo
                        //       al azar que hacer.
                        if (posicionXCasualidades.ContainsKey(i+1) && posicionYCasualidades.ContainsKey(i+1))
                        {
                            squares[i] = new CasualidadSquare("Casualidad", posicionXCasualidades[i+1], posicionYCasualidades[i+1]);
                        } else
                        {
                            if (i == 4)
                            {
                                squares[i] = new HouseSquare("Income Tax", 0, 283, 360);
                            } else if (i == 38)
                            {
                                squares[i] = new HouseSquare("Luxury Tax", 0, 360, 283);
                            }
                        }
                        
                    }
                }
            }

            int z = 0;
            foreach(var sq in squares)
            {
                Trace.WriteLine(sq.getName() + " " + z++);
            }
        }

        public Square[] GetSquares()
        {
            return squares;
        }

        public void SetPlayers(Player[] players)
        {
            /*
           Array.Sort(players, delegate (Player p1, Player p2)
            {
                return p1.getID().CompareTo(p2.getID());

            });
            foreach(var pl in players)
            {
                Trace.WriteLine("PL: " + pl.getID());
            }*/
            this.players = players;
        }

        public String GetHouseBits(int position)
        {
            return houseBits[position];
        }

        public int GetHousePositionFromBits(String bits)
        {
            foreach (KeyValuePair<int, String> dic in houseBits)
            {
                if (dic.Value == bits)
                {
                    return dic.Key;
                }
            }
            return 0;
        }

        public void GeneratePlayers(int totalPlayer)
        {
            
            players = new Player[totalPlayer];
            this.totalPlayer = totalPlayer;
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player(i, "Player " + (i + 1));
            }       
        }

        public Square movePlayer(Player player, int dado1, int dado2)
        {
            return movePlayer(player, dado1, dado2, true);
        }

        public Square movePlayer(Player player, int dado1, int dado2, bool count)
        {
            if (player.isBrokeOut())
            {
                return squares[player.getCurrentPosition()];
            }
            if (dado1 == dado2)
            {
                dobles++;
                if (dobles == 3)
                {
                    dobles = 0;
                    player.setIsInJail(true);
                    return squares[10];
                }
            }
            int newPosition = normalizePosition(player.getCurrentPosition() + dado1 + dado2);
            player.setPosition(newPosition);
            Trace.WriteLine(player, player.getName() + " goes to " + squares[player.getCurrentPosition()].getName());
            //squares[newPosition].doAction(player, this);
            //if (player.getMoney().isBrokeOut())
            //{
            //    Trace.WriteLine(player, player.getName() + " has been broke out!");
            //    player.setBrokeOut(true);
            //}
            //else
            //{
            //    if (count)
            //   {
            //        player.nextTurn();
            //    }
            //}
            
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

        public static int normalizePosition(int position)
        {
            return position % 40;
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
            foreach(var p in this.players)
            {
                if (p.getID() == id)
                {
                    return p;
                }
            }

            throw new ArgumentException("Jugador no conseguido", "ID invalido");
        }

        public int getTotalSquare()
        {
            return squares.Length;
        }
    }
}
