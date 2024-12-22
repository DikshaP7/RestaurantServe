using HotelServeDLL.DataContext;
using HotelServeDLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelServer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableTapController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TableTapController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTable()
        {
            var tableno = _context.tblTableTap.ToList();
            _context.SaveChanges();
            return Ok(tableno);
        }

        [HttpGet("{id}")]
        public IActionResult GetTableID(int id)
        {
            var tableid = _context.tblTableTap.FirstOrDefault(x => x.TableID == id);
            if (tableid != null)
            {
                return Ok(tableid);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public IActionResult AddTable(int id, [FromBody] TableTap table)
        {
            var tableno = _context.tblTableTap.FirstOrDefault(x => x.TableID == id);
            if (tableno != null)
            {
                tableno.QRCode = table.QRCode;
                _context.tblTableTap.Add(table);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok(tableno);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTable(int id, [FromBody] TableTap tap)
        {
            var updatetbl = _context.tblTableTap.FirstOrDefault(y => y.TableID == id);
            if (updatetbl != null)
            {
                updatetbl.QRCode = tap.QRCode;
                _context.tblTableTap.Update(updatetbl);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok(updatetbl);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id)
        {
            var deletetbl = _context.tblTableTap.FirstOrDefault(x => x.TableID == id);
            if(deletetbl != null)
            {
                _context.tblTableTap.Remove(deletetbl);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok(deletetbl);
        }
    }
}
