using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VendingMachineWebAPI.Models;

namespace VendingMachineWebAPI.Data
{
    public class ItemRepository
    {
        private List<Item> all = new List<Item>();
        private List<Item> items = new List<Item>();
        private string path;

        public ItemRepository(string path)
        {
            int id = 1;
            this.path = path;
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var fields = line.Split(
                        new char[] { ',' },
                        StringSplitOptions.RemoveEmptyEntries);

                    if (fields.Length == 3)
                    {
                        all.Add(new Item
                        {
                            Id = id++,
                            Name = fields[0],
                            Price = decimal.Parse(fields[1]),
                            Quantity = int.Parse(fields[2])
                        });

                    }
                }
            }

            var rand = new Random();
            var itemCount = 8 + rand.Next(7);
            for (int i = 0; i < itemCount; i++)
            {
                Item item = null;
                do
                {
                    item = all[rand.Next(all.Count)];
                } while (items.Contains(item));
                items.Add(item);
            }
        }

        public IEnumerable<Item> All()
        {
            return items;
        }

        public Item FindById(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }

        public void Save(Item item)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var i in all)
                {
                    writer.WriteLine(string.Join(",", i.Name, i.Price, i.Quantity));
                }
            }
        }
    }
}