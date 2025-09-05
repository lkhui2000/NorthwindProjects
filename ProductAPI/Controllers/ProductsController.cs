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
    public class ProductsController : ODataController
    {
        private readonly NorthwindContext _context;

        public ProductsController(NorthwindContext context)
        {
            _context = context;
        }

        //[HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<Product>> Get()
        {
            return this.Ok(_context.Products.AsQueryable());
        }


        //[HttpGet]
        [EnableQuery]
        public ActionResult<Product> Get([FromRoute] int key)
        {
            var item = _context.Products.Find(key);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}
