using BuyPizza.DataControllers;
using BuyPizza.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BuyPizza.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemObject _iItemObject;
        public ItemController(ILogger<ItemController> logger, IItemObject iItemObject)
        {
            _logger = logger;
            _iItemObject = iItemObject;
        }

        [HttpGet]
        public GetItemListModel GetPizzaItems()
        {
            return _iItemObject.GetItemList();
        }

        [HttpGet]
        public GetItemToppingListModel GetPizzaItemToppings(long itemId)
        {
            return _iItemObject.GetItemToppingList(itemId);
        }
    }
}