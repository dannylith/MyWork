using DannyLithyouvong.Powerball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball.Data
{
    public class PickInMemoryRepository : IPickRepository
    {
        private int currentId = 1;
        private List<Pick> picks = new List<Pick>();

        public int GetID() {  return currentId;  }

        public PickInMemoryRepository()
        {
            picks.Add(new Pick {
                Name = "Test",
                ID = currentId,
                NumberOne = 7,
                NumberTwo = 8,
                NumberThree = 9,
                NumberFour = 10,
                NumberFive = 11,
                Powerball = 12
            });
            currentId += 1;
        }

        public List<Pick> GetPicksList()
        {
            return new List<Pick>(picks);
        }

        public void AddPick(Pick pick)
        {
            pick.ID = currentId;
            picks.Add(pick);

            currentId++;
        }


    }
}
