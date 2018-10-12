using BattleShip.BLL.GameLogic;
using System;

namespace BattleShip.UI
{


    public class Player
    {

        private Board board = new Board();


        public Board GetBoard { get { return board; } }

        public string Name { get; set; }

        public Player(string prompt)
        {
            Console.Write(prompt);
            Name = Console.ReadLine();
        }

        
    }
}
