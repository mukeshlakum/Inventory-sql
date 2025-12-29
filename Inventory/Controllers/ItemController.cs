using Inventory.Entities;
using Inventory.Model;
using Inventory.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Inventory.Controllers
{
    [Route("")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        public IItemService _itemservice { get; }

        public ItemController(IItemService itemservice   )
        {
            _itemservice = itemservice;
        }

        [HttpGet("api/items")]
        public async Task<ActionResult> GetItems([FromQuery] string? name)
        {
            return Ok(await _itemservice.GetItemsAsync());
        }

        [HttpGet("api/items/{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var item = await _itemservice.GetItemAsync(id);
            if (item == null)
            {
                return BadRequest("Item not found");
            }
            return Ok(item);
        }

        [HttpPost("api/items")]
        public async Task<ActionResult<ItemDto>> Add(ItemDto itemdto)
        {
            var item = await _itemservice.AddItemAsync(itemdto);
            if (item == null)
            {
                return BadRequest("Item already exists!");
            }
            return Ok(item);
        }

        [HttpPut("api/items/{id}")]
        public async Task<ActionResult<ItemDto>> Update(int id, ItemDto itemdto)
        {
            var item = await _itemservice.UpdateItemAsync(id, itemdto);
            if (item == null)
            {
                return BadRequest("Item id does not exists!");
            }
            return Ok(item);
        }

        [HttpDelete("api/items/{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var result = await _itemservice.DeleteItemAsync(id);
            if (result == false)
            {
                return BadRequest("Item id does not exists!");
            }
            return Ok();
        }
    }
}
