using DannyLithyouvong.Powerball.Data;
using DannyLithyouvong.Powerball.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannyLithyouvong.Powerball.Domain
{
    public class Service
    {
        private IPickRepository repo;
        private IPickGetter pickGetter;

        public Service(IPickRepository repo, IPickGetter pickGetter)
        {
            this.repo = repo;
            this.pickGetter = pickGetter;
        }

        public UserPickResponse UserPick(string name, int pick1, int pick2, int pick3, int pick4, int pick5, int powerball)
        {
            UserPickResponse response = new UserPickResponse();

            //check to make sure all numbers are unique
            List<int> numbers = new List<int>() { pick1, pick2, pick3, pick4, pick5 };
            if (numbers.Distinct().Count() != 5)
            {
                response.Success = false;
                response.Message = "Your numbers are not all unique. There is a duplicate somewhere.";
                return response;
            }

            if (numbers.Where(n => n < 1 || n > 69).Count() > 0)
            {
                response.Success = false;
                response.Message = "One or more of the pick is not between 1-69.";
                return response;
            }

            if(powerball < 1 || powerball > 26)
            {
                response.Success = false;
                response.Message = "The powerball is not between 1-26";
                return response;
            }

            //create new pick then add it to the repository
            Pick userPick = new Pick
            {
                Name = name,
                NumberOne = pick1,
                NumberTwo = pick2,
                NumberThree = pick3,
                NumberFour = pick4,
                NumberFive = pick5,
                Powerball = powerball
            };
            response.Success = true;
            response.PickResponse = userPick;
            repo.AddPick(userPick);
            return response;
        }

        public GetPickListResponse GetPicks()
        {
            GetPickListResponse response = new GetPickListResponse();
            List<Pick> picks = repo.GetPicksList();

            if (!picks.Any())
            {
                response.Success = false;
                response.Message = "There are no tickets bought.";
                response.picks = picks;
                return response;
            }
            response.Success = true;
            response.picks = picks;
            return response;
        }

        public UserPickResponse LookupPick(int id)
        {
            UserPickResponse response = new UserPickResponse();
            var picks = repo.GetPicksList();

            foreach(var p in picks)
            {
                if(p.ID == id)
                {
                    response.Success = true;
                    response.PickResponse = p;
                    return response;
                }
            }
            response.Success = false;
            response.Message = $"ID {id} cannot be found.";
            return response;
        }

        public Pick QuickPick(string name)
        {
            Pick computerPick = pickGetter.PickGetter();//computer will generate pick

            //fill out the rest of the pick information then add to respository
            computerPick.Name = name;
            computerPick.ID = repo.GetID();
            repo.AddPick(computerPick);

            return computerPick;


        }

        public DrawResponse Draw()
        {
            DrawResponse response = new DrawResponse();
            Pick winningPick = pickGetter.PickGetter(); //computer will generate winning pick
            int[] arrWinPick = winningPick.GetNumbers;//put winning pick into an array

            //store winning pick array and powerball into response
            response.WinningPickArray = arrWinPick;
            response.Powerball = winningPick.Powerball;
            
            //get the picks from respository
            var pickLists = repo.GetPicksList();

            //declare variables
            List<Pick> winningPicksList;
            Dictionary<int, List<Pick>> winningPicksDictionary = new Dictionary<int, List<Pick>>();

            //used to keep track of any matches to winning pick
            int countMatch = 0;

            //no need to contine if there is no picks to compare
            if (!pickLists.Any())
            {
                response.Success = false;
                response.Message = "There were no tickets bought during the draw.";
                return response;
            }
            
            //loop through each pick object and compare their array to the winning array
            foreach (var p in pickLists)
            {
                countMatch = 0;
                foreach (var n in p.GetNumbers)
                {

                    foreach (var d in arrWinPick)
                    {
                        if (n == d)
                        {
                            countMatch++;
                        }
                    }

                }
                if (countMatch > 0)//store any winning matches to a list then a dictionary
                {
                    if (winningPicksDictionary.ContainsKey(countMatch))
                    {
                        winningPicksList = winningPicksDictionary[countMatch];
                        winningPicksList.Add(p);
                        winningPicksDictionary[countMatch] = winningPicksList;
                    }
                    else
                    {
                        winningPicksList = new List<Pick>();
                        winningPicksList.Add(p);
                        winningPicksDictionary.Add(countMatch, winningPicksList);
                    }
                }
            }

            //return no winners
            if (!winningPicksDictionary.Any())
            {
                response.Success = false;
                response.Message = "There are no winners.";
                return response;
            }

            var winners = winningPicksDictionary.GroupBy(p => p.Key).OrderByDescending(g => g.Key).Take(1);

            //store only picks with highest matches to the winning pick
            winningPicksList = new List<Pick>();
            foreach (var g in winners)
            {
                foreach (var k in g)
                {
                    foreach (var p in k.Value)
                    {
                        winningPicksList.Add(p);
                    }
                }
            }

            response.Success = true;
            response.Message = "Winner(s):";
            response.WinningPicksList = winningPicksList;
            return response;

        }
    }
}
