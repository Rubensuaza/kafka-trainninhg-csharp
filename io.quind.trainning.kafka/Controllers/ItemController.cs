using io.quind.trainning.kafka.domain.models;
using io.quind.trainning.kafka.domain.ports.inputs;
using Microsoft.AspNetCore.Mvc;

namespace io.quind.trainning.kafka.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ItemController: ControllerBase
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateItem(Item item)
        {
            var id = await itemService.Create(item);
            return await GetItemById(id);

        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetItemById(int id)
        {
            return Ok(await itemService.GetItemById(id));

        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            return Ok(await itemService.GetItems());
        }
    }
}
