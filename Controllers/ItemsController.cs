using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Dtos;
using catalog.Entities;
using catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsRepositoryInterface repository;

        public ItemsController(ItemsRepositoryInterface repository)
        {
            this.repository = repository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            return (await repository.GetItemsAsync()).Select(item => item.AsDto());    
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemByIdAsync(Guid id)
        {
            var item = await repository.GetItemByIdAsync(id);

            if(item is null)
                return NotFound();

            return item.AsDto();    
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(ItemCreateDto itemDto)
        {
            Item item = new Item(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            }; 

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemsAsync), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, ItemUpdateDto itemDto)
        {
            var existingItem = await repository.GetItemByIdAsync(id);
            if(existingItem is null)
                return NotFound();

            Item updateItem = existingItem with { // only record type can take with
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            await repository.UpdateItemAsync(updateItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await repository.GetItemByIdAsync(id);
            if(existingItem is null)
                return NotFound();

            await repository.DeleteItemAsync(id);

            return NoContent();
        }
    }
}