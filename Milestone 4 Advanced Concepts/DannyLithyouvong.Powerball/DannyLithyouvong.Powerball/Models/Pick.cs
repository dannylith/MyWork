using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball.Models
{
    public class Pick
    {
        private int[] numbers = new int[5];
        public string Name { get; set; }
        public int ID { get; set; }
        public int[] GetNumbers { get { return numbers; } }
        public int NumberOne
        {
            get { return numbers[0]; }
            set { numbers[0] = value; }
        }
        public int NumberTwo
        {
            get { return numbers[1]; }
            set { numbers[1] = value; }
        }
        public int NumberThree
        {
            get { return numbers[2]; }
            set { numbers[2] = value; }
        }
        public int NumberFour
        {
            get { return numbers[3]; }
            set { numbers[3] = value; }
        }
        public int NumberFive
        {
            get { return numbers[4]; }
            set { numbers[4] = value; }
        }
        public int Powerball { get; set; }

    }
}
