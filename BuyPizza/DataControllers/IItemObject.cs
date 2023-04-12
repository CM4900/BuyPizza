using BuyPizza.ViewModels;

namespace BuyPizza.DataControllers
{
    public interface IItemObject
    {
        GetItemListModel GetItemList();
        GetItemToppingListModel GetItemToppingList(long itemID);
    }
}
