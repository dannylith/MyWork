using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using VendingMachineWebAPI.Data;
using VendingMachineWebAPI.Models;

namespace VendingMachineWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemController : ApiController
    {
        private static readonly Lazy<ItemRepository> repository
            = new Lazy<ItemRepository>(MakeRepository);

        private ItemRepository Repository
        {
            get { return repository.Value; }
        }

        [Route("items")]
        public IEnumerable<Item> GetItems()
        {
            return Repository.All();
        }

        [Route("money/{money}/item/{id}")]
        [HttpGet]
        public HttpResponseMessage Vend(decimal money, int id)
        {

            var item = Repository.FindById(id);
            if (item == null)
            {
                return Request.CreateResponse(
                    HttpStatusCode.NotFound,
                    new { message = "That's an invalid item." });
            }

            if (item.Quantity <= 0)
            {
                return Request.CreateResponse(
                   (HttpStatusCode)422,
                   new { message = "SOLD OUT!!!" });
            }

            if (item.Price > money)
            {
                return Request.CreateResponse(
                   (HttpStatusCode)422,
                   new { message = $"Please deposit: {(item.Price - money):C}" });
            }

            item.Quantity--;
            Repository.Save(item);
            return Request.CreateResponse(HttpStatusCode.OK, new Change(money - item.Price));
        }

        private static ItemRepository MakeRepository()
        {
            return new ItemRepository(
                    HttpContext.Current.Server.MapPath("~/App_Data/items.txt")
                );
        }

    }
}
