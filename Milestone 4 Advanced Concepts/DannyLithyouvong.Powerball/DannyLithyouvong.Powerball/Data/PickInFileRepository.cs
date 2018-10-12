using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DannyLithyouvong.Powerball.Models;

namespace DannyLithyouvong.Powerball.Data
{
    public class PickInFileRepository: IPickRepository
    {
        private const string filePath = @".\PicksList.txt";
        private List<Pick> picks = new List<Pick>();
        private int currentId = 1;
        public int GetID() {  return currentId; }


        public PickInFileRepository()
        {

            File.Create(filePath).Close();

        }

        public List<Pick> GetPicksList()
        {
            picks = new List<Pick>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    if (columns.Length == 8)
                    {
                        
                        picks.Add(new Pick
                        {
                            ID = int.Parse(columns[0]),
                            Name = columns[1],
                            NumberOne = int.Parse(columns[2]),
                            NumberTwo = int.Parse(columns[3]),
                            NumberThree = int.Parse(columns[4]),
                            NumberFour = int.Parse(columns[5]),
                            NumberFive = int.Parse(columns[6]),
                            Powerball = int.Parse(columns[7])
                        });
                    }
                }
            }
            return picks;
        }

        public void AddPick(Pick pick)
        {
            List<Pick> newPicks = GetPicksList();
            pick.ID = currentId;
            newPicks.Add(pick);
            currentId++;

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach(var p in newPicks)
                {
                    sw.WriteLine($"{p.ID},{p.Name},{p.NumberOne},{p.NumberTwo},{p.NumberThree},{p.NumberFour},{p.NumberFive},{p.Powerball}");
                }
                
            }
        }
    }
}
