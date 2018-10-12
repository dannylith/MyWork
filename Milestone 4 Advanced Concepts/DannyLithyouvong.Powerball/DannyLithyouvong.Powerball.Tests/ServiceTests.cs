using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DannyLithyouvong.Powerball.Data;
using DannyLithyouvong.Powerball.Domain;
using DannyLithyouvong.Powerball.Models;
using NUnit.Framework;

namespace DannyLithyouvong.Powerball.Tests
{
    [TestFixture]
    public class ServiceTests
    {

        [Test]
        public void UserCanNotChooseLessThan1orGreaterThan69()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickRandom());

            UserPickResponse actual = service.UserPick("test", -1, -2, 70, 71, 100, 50);

            Assert.IsFalse(actual.Success);
            Assert.IsNull(actual.PickResponse);
        }

        [Test]
        public void UserCanChooseBetween1to69()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickRandom());

            UserPickResponse actual = service.UserPick("test", 1, 2, 69, 50, 20, 10);

            Assert.IsTrue(actual.Success);
            Assert.AreEqual(1, actual.PickResponse.NumberOne);
            Assert.AreEqual(2, actual.PickResponse.NumberTwo);
            Assert.AreEqual(69, actual.PickResponse.NumberThree);
            Assert.AreEqual(50, actual.PickResponse.NumberFour);
            Assert.AreEqual(20, actual.PickResponse.NumberFive);
            Assert.AreEqual(10, actual.PickResponse.Powerball);
        }

        [Test]
        public void PicksCannotBeDuplicate()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickRandom());

            UserPickResponse actual = service.UserPick("test", 1, 1, 1, 1, 1, 50);

            Assert.IsFalse(actual.Success);
            Assert.IsNull(actual.PickResponse);

        }

        [Test]
        public void CanWinInDraw()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickManual
            {
                Pick1 = 1,
                Pick2 = 2,
                Pick3 = 3,
                Pick4 = 4,
                Pick5 = 5
            });
            repo.AddPick(new Pick
            {
                Name = "Test",
                NumberOne = 1,
                NumberTwo = 2,
                NumberThree = 3,
                NumberFour = 4,
                NumberFive = 5,
                Powerball = 6
            });

            DrawResponse actual = service.Draw();

            Assert.IsTrue(actual.Success);
        }

        [Test]
        public void NoWinnersInDraw()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickManual());

            DrawResponse actual = service.Draw();

            Assert.IsFalse(actual.Success);
        }

        [Test]
        public void QuickPickWillChoose123456()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickManual
            {
                Pick1 = 1,
                Pick2 = 2,
                Pick3 = 3,
                Pick4 = 4,
                Pick5 = 5,
                Powerball = 6
            });

            Pick actual = service.QuickPick("test");

            Assert.AreEqual(1, actual.NumberOne);
            Assert.AreEqual(2, actual.NumberTwo);
            Assert.AreEqual(3, actual.NumberThree);
            Assert.AreEqual(4, actual.NumberFour);
            Assert.AreEqual(5, actual.NumberFive);
            Assert.AreEqual(6, actual.Powerball);

        }

        [Test]
        public void CanLookupPick()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickManual());

            UserPickResponse actual = service.LookupPick(1);

            Assert.IsTrue(actual.Success);
        }

        [Test]
        public void CanNotLookupPick()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickManual());

            UserPickResponse actual = service.LookupPick(10);

            Assert.IsFalse(actual.Success);
        }

        [Test]
        public void CanGetPickLists()
        {
            IPickRepository repo = new PickInMemoryRepository();
            Service service = new Service(repo, new PickManual());

            GetPickListResponse actual = service.GetPicks();

            Assert.IsTrue(actual.Success);
            Assert.IsTrue(actual.picks.Count() > 0);
        }

        [Test]
        public void CanNotGetPickLists()
        {
            IPickRepository repo = new PickInFileRepository();
            Service service = new Service(repo, new PickManual());

            GetPickListResponse actual = service.GetPicks();

            Assert.IsFalse(actual.Success);
            Assert.IsTrue(actual.picks.Count() == 0);
        }

        [Test]
        public void CanWriteAndReadToAndFromFileRepository()
        {
            IPickRepository repo = new PickInFileRepository();
            Service service = new Service(repo, new PickManual
            {
                Pick1 = 1,
                Pick2 = 2,
                Pick3 = 3,
                Pick4 = 4,
                Pick5 = 5,
                Powerball = 6
            });

            service.QuickPick("test");

            var picks = repo.GetPicksList();

            Assert.IsTrue(picks.Count() == 1);
            Assert.AreEqual(1, picks.First().ID);
            Assert.AreEqual(1, picks.First().NumberOne);
            Assert.AreEqual(2, picks.First().NumberTwo);
            Assert.AreEqual(3, picks.First().NumberThree);
            Assert.AreEqual(4, picks.First().NumberFour);
            Assert.AreEqual(5, picks.First().NumberFive);
            Assert.AreEqual(6, picks.First().Powerball);
        }
    }
}
