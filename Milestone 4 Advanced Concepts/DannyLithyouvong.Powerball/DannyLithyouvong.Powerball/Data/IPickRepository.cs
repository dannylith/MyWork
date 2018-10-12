using DannyLithyouvong.Powerball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball.Data
{
    public interface IPickRepository
    {
        List<Pick> GetPicksList();
        void AddPick(Pick pick);
        int GetID();
    }
}
