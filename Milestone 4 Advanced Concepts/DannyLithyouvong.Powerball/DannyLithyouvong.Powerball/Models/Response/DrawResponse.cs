﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball.Models
{
    public class DrawResponse : Response
    {        
        public List<Pick> WinningPicksList { get; set; }
        public int[] WinningPickArray { get; set; }
        public int Powerball { get; set; }
    }
}
