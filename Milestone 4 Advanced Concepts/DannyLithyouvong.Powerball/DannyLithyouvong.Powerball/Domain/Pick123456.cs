using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DannyLithyouvong.Powerball.Models;

namespace DannyLithyouvong.Powerball.Domain
{
    public class Pick123456 : IPickGetter
    {
        public Pick PickGetter()
        {
            Pick p = new Pick();

            p.NumberOne = 1;
            p.NumberTwo = 2;
            p.NumberThree = 3;
            p.NumberFour = 4;
            p.NumberFive = 5;
            p.Powerball = 6;

            return p;
        }
    }
}
