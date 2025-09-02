using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using NorthwindDataStorage.Models;
using System;

namespace ProductAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<Product>> Get()
        {
            return this.Ok(_context.Products.AsQueryable());
        }
    }
}
