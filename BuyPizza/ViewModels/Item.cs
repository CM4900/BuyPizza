namespace BuyPizza.ViewModels
{
    public class Item
    {
    }

    public class ItemListModel
    {
        public long itemID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public String imageBase { get; set; }
        public Decimal rate { get; set; }
    }
    public class GetItemListModel
    {
        public bool hasError { get; set; } = false;
        public int errorCode { get; set; }
        public string errorMsg { get; set; }

        public List<ItemListModel> lstItemListModel { get; set; }
    }

    public class ItemToppingListModel
    {
        public long itemToppingID { get; set; }
        public long itemID { get; set; }
        public long toppingID { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        public string toppingName { get; set; }
        public String imageBase { get; set; }
        public Decimal rate { get; set; }
    }
    public class GetItemToppingListModel
    {
        public bool hasError { get; set; } = false;
        public int errorCode { get; set; }
        public string errorMsg { get; set; }

        public List<ItemToppingListModel> lstItemToppingListModel { get; set; }
    }
}
