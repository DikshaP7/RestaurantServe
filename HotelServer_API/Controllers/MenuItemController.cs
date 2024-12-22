using HotelServeDLL.DataContext;
using HotelServeDLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

        [HttpPost]
        public IActionResult AddMenuItems([FromBody] MenuItem menuItem)
        {
            _Context.tblMenuItems.Add(menuItem);
            _Context.SaveChanges();
            return Ok(menuItem);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(int id,[FromBody] MenuItem menuItem)
        {
            var existingItem = _Context.tblMenuItems.FirstOrDefault(x => x.MenuItemID == id);
            if (existingItem != null)
            {
                existingItem.Name = menuItem.Name;
                existingItem.Description = menuItem.Description;
                existingItem.Price = menuItem.Price;
                existingItem.Category = menuItem.Category;
                existingItem.ImageUrl = menuItem.ImageUrl;
                _Context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(existingItem);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            var deleteMenu = _Context.tblMenuItems.FirstOrDefault(x => x.MenuItemID == id);
            if(deleteMenu != null)
            {
                _Context.tblMenuItems.Remove(deleteMenu);
                _Context.SaveChanges();
            }
            else
            {
                return NoContent();
            }
            return Ok(deleteMenu);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenuItemId(int id)
        {
            var menu = _Context.tblMenuItems.FirstOrDefault(x => x.MenuItemID == id);
            if(menu != null)
            {
                return Ok(menu);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
