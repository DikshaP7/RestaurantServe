using HotelServeDLL.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly AppDbContext _Context;

        public MenuItemController(AppDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult GetMenuItems()
        {
            var menuItems = _Context.tblMenuItems.ToList();
            return Ok(menuItems);
        }
    }
}
