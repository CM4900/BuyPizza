namespace BuyPizza.ViewModels
{
    public class Item
    {
    }

    public class ItemListModel
    {
        public long ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String ImageBase { get; set; }
        public Double Rate { get; set; }
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
        public long ItemToppingID { get; set; }
        public long ItemID { get; set; }
        public long ToppingID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ToppingName { get; set; }
        public String ImageBase { get; set; }
        public Double Rate { get; set; }
    }
    public class GetItemToppingListModel
    {
        public bool hasError { get; set; } = false;
        public int errorCode { get; set; }
        public string errorMsg { get; set; }

        public List<ItemToppingListModel> lstItemToppingListModel { get; set; }
    }
}
