using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetWebApiAtaturkQuotes.Models;
namespace DotNetWebApiAtaturkQuotes.Controllers
{
    public class QuoteController : ApiController
    {
        AtaturkQuotesEntities DB = new AtaturkQuotesEntities();
        public IEnumerable<Quotes> Get()
        {
            return DB.Quotes.ToList();
        }
        public IHttpActionResult Get(int Id)
        {
            Quotes Quote;
            if (Id == 0)
            {
                Random rand = new Random();
                List<Quotes> _Quotes = DB.Quotes.ToList();
                Quote = _Quotes[rand.Next(_Quotes.Count())];
            }
            else
            {
                Quote = DB.Quotes.Where(x => x.Id == Id).SingleOrDefault();
            }
            if (Quote == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Quote);
            }
        }
    }
}