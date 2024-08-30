namespace WebAPICoreTask1.DTOS
{
    public class CartItemResponseDTO
    {
        public int CartItemId { get; set; }
        public int? CartId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public ProductResponseDTO? prodcutDTO { get; set; }

    }

    //public class ProductDTO
    //{


    //    public string? ProductName { get; set; }

    //    public string? Description { get; set; }

    //    public decimal? Price { get; set; }

    //    public string? ProductImage { get; set; }



    //}
}
