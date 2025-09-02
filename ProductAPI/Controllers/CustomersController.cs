using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using NorthwindDataStorage.Models;
using System;

namespace ProductAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
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
    }
}
