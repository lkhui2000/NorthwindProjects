using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using NorthwindDataStorage.Models;
using System;

namespace ProductAPI.Controllers
{
    //[Route("odata/[controller]")]
    //[ApiController]
    public class CustomersController : ODataController
    {
        private readonly NorthwindContext _context;

        public CustomersController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<Customer>> Get()
        {
            return this.Ok(_context.Customers.AsQueryable());
        }

        //[HttpGet]
        //[EnableQuery]
        //public ActionResult<Customer> Get([FromRoute] int key)
        //{
        //    var item = _context.Customers.Find(key);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(item);
        //}
    }
}
