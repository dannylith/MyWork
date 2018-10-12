using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DannyLithyouvong.Powerball.Models;

namespace DannyLithyouvong.Powerball.Domain
{
    public class PickManual : IPickGetter
    {
        public int Pick1 { get; set; }
        public int Pick2 { get; set; }
        public int Pick3 { get; set; }
        public int Pick4 { get; set; }
        public int Pick5 { get; set; }
        public int Powerball { get; set; }

        public Pick PickGetter()
        {
            Pick p = new Pick();

            p.NumberOne = Pick1;
            p.NumberTwo = Pick2;
            p.NumberThree = Pick3;
            p.NumberFour = Pick4;
            p.NumberFive = Pick5;
            p.Powerball = Powerball;

            return p;
        }
    }
}
