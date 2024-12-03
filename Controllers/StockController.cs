using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class StockController  : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        /*[HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
            .Select(s => s.ToStockDto());
            return Ok(stocks);
        }*/
        // GET: api/stock
        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return Ok(stocks.Select(stock => stock.ToStockDto()));
        }



        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        
        /*[HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto. ToStockFromCreateDTO();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }*/
        // POST: api/stock
        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] CreateStockRequestDto request)
        {
            var stock = request.ToStockFromCreateDTO();
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStocks), new { id = stock.Id }, stock.ToStockDto());
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id == id);
            if(stockModel == null)
            {
                return NotFound();
            }
            stockModel.ItemName = updateDto.ItemName;
            stockModel.ExpiryDate = updateDto.ExpiryDate;

            _context.SaveChanges();
            
            return Ok(stockModel.ToStockDto());
        }
        /*[HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stocks.FirstOrDefault(x => x.Id ==id);
            if (stockModel == null)
            {
                return NotFound();
            }
            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return NoContent();
        }*/
        // DELETE: api/stock/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
