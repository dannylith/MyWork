using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlooringOrderingSystem.Data
{
    public class TaxFileRepository : ITaxFileRepository
    {
        private const string filePath = @".\Taxes.txt";

        public IEnumerable<Tax> GetAll()
        {
            List<Tax> taxes = new List<Tax>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    taxes.Add(new Tax
                        {
                            StateAbbreviation = columns[0],
                            StateName = columns[1],
                            TaxRate = decimal.Parse(columns[2])

                        });
                }
            }
            return taxes;

        }

        public Tax FindByState(string state)
        {
            return GetAll().Where(t => t.StateName.ToUpper() == state.ToUpper()  || t.StateAbbreviation.ToUpper() == state.ToUpper()).FirstOrDefault();
        }
    }
}
