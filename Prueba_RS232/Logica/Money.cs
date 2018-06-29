using System;
using System.Collections.Generic;
using System.Text;

namespace Monopolio_RS232.Logica
{
    class Money
    {
        int money;

        public Money()
        {
            money = 0;
        }

        public Money(int money)
        {
            this.money = money;
        }

        public int getMoney()
        {
            return money;
        }

        public void addMoney(int amount)
        {
            money += amount;
        }

        public void substractMoney(int amount)
        {
            money -= amount;
        }

        public bool isBrokeOut()
        {
            return money < 0;
        }
    }
}
