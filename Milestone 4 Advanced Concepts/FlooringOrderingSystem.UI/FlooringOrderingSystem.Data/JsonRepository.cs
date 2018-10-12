using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Data
{
    public class JsonRepository
    {
        private const string filePathBegin = @".\Orders_";
        private const string filePathEnd = ".json";

        public void CreateJson(List<Order> orders, string date)
        {
            var jsonList = JsonConvert.SerializeObject(orders);
            File.WriteAllText(filePathBegin + date + filePathEnd, jsonList);
        }
    }
}
