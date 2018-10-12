using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldAgent.Domain
{
    public class Alias
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static IEnumerable<Alias> All()
        {
            yield return new Alias { Id = 1, Name = "The Spy" };
            yield return new Alias { Id = 2, Name = "Agent 99" };
            yield return new Alias { Id = 3, Name = "Jason Borne" };
            yield return new Alias { Id = 4, Name = "Jack Ryan" };
            yield return new Alias { Id = 5, Name = "Solid Snake" };
            yield return new Alias { Id = 6, Name = "Jack Bauer" };
            yield return new Alias { Id = 7, Name = "Nick Fury" };
            yield return new Alias { Id = 8, Name = "Agent J" };
            yield return new Alias { Id = 9, Name = "Agent K" };
        }
    }
}
