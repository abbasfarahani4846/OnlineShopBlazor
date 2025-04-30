namespace OnlineShopBlazor.Models.ViewModels
{
    public class CartViewItemViewModel
    {
        public int ProductId { get; set; }
        public string? Title { get; set; }
        public string? ImageName { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Count { get; set; }
        public decimal RowSum { get; set; }
    }
}
