using BuyPizza.ViewModels;

namespace BuyPizza.DataControllers
{
    public interface IItemObject
    {
        GetItemListModel GetItemList(long itemID);
        GetItemToppingListModel GetItemToppingList(long itemID);
    }
}
