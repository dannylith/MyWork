using DannyLithyouvong.Powerball.Data;
using DannyLithyouvong.Powerball.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller(new PickInFileRepository(), new PickRandom());
            controller.Run();
        }
    }
}
