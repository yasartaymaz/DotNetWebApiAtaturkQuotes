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
            var Quote = DB.Quotes.Where(x => x.Id == Id);
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