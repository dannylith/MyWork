using DannyLithyouvong.Powerball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball.Domain
{
    public class PickRandom : IPickGetter
    {
        public Pick PickGetter()
        {
            Pick computerPick = new Pick();
            List<int> numbers;

            Random r = new Random();

            //computer will randomly generate the pick
            do
            {
                computerPick.NumberOne = r.Next(1, 70);
                computerPick.NumberTwo = r.Next(1, 70);
                computerPick.NumberThree = r.Next(1, 70);
                computerPick.NumberFour = r.Next(1, 70);
                computerPick.NumberFive = r.Next(1, 70);
                numbers = new List<int>() { computerPick.NumberOne, computerPick.NumberTwo, computerPick.NumberThree, computerPick.NumberFour, computerPick.NumberFive };

            } while (numbers.Distinct().Count() != 5);
            computerPick.Powerball = r.Next(1, 27);

            return computerPick;
        }
    }
}
